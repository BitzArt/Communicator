using BitzArt.Flux.REST;
using BitzArt.Pagination;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace BitzArt.Flux;

internal partial class RequestParameterParsingUtility
{
    public static RequestUrlParameterParsingResult ParseRequestUrl(string path, IRestRequestParameters? parameters, IRequestPreparationParameters preparationParameters)
    {
        var matches = ParameterRegex().Matches(path);
        if (matches.Count == 0)
        {
            if (preparationParameters.PageRequest is not null)
                path = ApplyPaging(path, preparationParameters.PageRequest);

            return new RequestUrlParameterParsingResult(path, string.Empty);
        }

        if (parameters is null) throw new ParametersNotFoundException();

        var resultBuilder = new StringBuilder(path);
        var logBuilder = new StringBuilder('\n');

        foreach (Match match in matches)
        {
            var parameterName = match.Groups[1].Value;
            var found = parameters.ValueMap.TryGetValue(parameterName, out var value);

            if (!found) throw new ParameterNotFoundException(parameterName);

            resultBuilder.Replace(match.Value, value!.ToString());

            if (logBuilder.Length > 1) logBuilder.Append("; ");
            logBuilder.Append($"{parameterName}: {value}");
        }

        var result = resultBuilder.ToString();

        if (preparationParameters.PageRequest is not null)
            result = ApplyPaging(result, preparationParameters.PageRequest);

        return new RequestUrlParameterParsingResult(result, logBuilder.ToString());
    }

    // TODO: review this
    private static string ApplyPaging(string path, PageRequest pageRequest)
    {
        var queryIndex = path.IndexOf('?');

        var query = queryIndex == -1 ?
            HttpUtility.ParseQueryString(string.Empty) :
            HttpUtility.ParseQueryString(path[queryIndex..]);

        query.Add("offset", pageRequest.Offset?.ToString());
        query.Add("limit", pageRequest.Limit?.ToString());

        if (queryIndex != -1) path = path[..queryIndex];
        path = path + "?" + query.ToString();

        return path;
    }

    [GeneratedRegex("{(.*?)}")]
    private static partial Regex ParameterRegex();

    private class ParametersNotFoundException() 
        : Exception("Parameters are specified in endpoint configuration but not found in the request.")
    {
    }

    private class ParameterNotFoundException(string parameterName)
        : Exception($"Parameter '{parameterName}' is specified in endpoint configuration but not found in the request.")
    {
    } 
}

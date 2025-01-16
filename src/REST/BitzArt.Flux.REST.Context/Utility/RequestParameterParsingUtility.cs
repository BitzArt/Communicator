using BitzArt.Flux.REST;
using System.Text;
using System.Text.RegularExpressions;

namespace BitzArt.Flux;

internal partial class RequestParameterParsingUtility
{
    public static RequestUrlParameterParsingResult ParseRequestUrl(string path, IRestRequestParameters parameters)
    {
        var matches = ParameterRegex().Matches(path);
        if (matches.Count == 0) return new RequestUrlParameterParsingResult(path, string.Empty);

        var requiredCount = matches.Count;
        var foundCount = parameters.Parameters.Count;

        if (requiredCount != foundCount) 
            throw new ParameterCountDidNotMatchException(foundCount, requiredCount);

        var result = path;

        var logBuilder = new StringBuilder();
        logBuilder.Append('\n');

        foreach (Match match in matches)
        {
            var parameterName = match.Groups[1].Value;
            var found = parameters.Parameters.TryGetValue(parameterName, out var value);
            if (!found) throw new ParameterNotFoundException(parameterName);

            result = result.Replace(match.Value, value!.ToString());

            logBuilder.Append($"{parameterName}: {value}\n");
        }

        return new RequestUrlParameterParsingResult(result, logBuilder.ToString());
    }

    [GeneratedRegex("{(.*?)}")]
    private static partial Regex ParameterRegex();
}

file class ParameterCountDidNotMatchException(int found, int required)
    : Exception($"Number of parameters in a request ({found}) did not match number of required parameters ({required}) for this endpoint.")
{
}

file class ParameterNotFoundException(string parameterName) 
    : Exception($"Parameter '{parameterName}' is specified in endpoint configuration but not found in the request.")
{
}

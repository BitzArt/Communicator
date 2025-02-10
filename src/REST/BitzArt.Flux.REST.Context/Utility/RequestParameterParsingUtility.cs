using System.Text;
using System.Text.RegularExpressions;

namespace BitzArt.Flux;

internal partial class RequestParameterParsingUtility
{
    public static string ParseRequestUrl(string path, IRestRequestParameters? parameters)
    {
        var matches = ParameterRegex().Matches(path);
        if (matches.Count == 0) return string.Empty;

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

        return resultBuilder.ToString();
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

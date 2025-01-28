﻿using BitzArt.Flux.REST;
using System.Text;
using System.Text.RegularExpressions;

namespace BitzArt.Flux;

internal partial class RequestParameterParsingUtility
{
    public static RequestUrlParameterParsingResult ParseRequestUrl(string path, IRestRequestParameters? parameters = null)
    {
        var matches = ParameterRegex().Matches(path);
        if (matches.Count == 0) return new RequestUrlParameterParsingResult(path, string.Empty);

        if (parameters is null) throw new ParametersNotFoundException();

        var resultBuilder = new StringBuilder(path);
        var logBuilder = new StringBuilder('\n');

        foreach (Match match in matches)
        {
            var parameterName = match.Groups[1].Value;
            var parameter = TryGetParameter(parameters, parameterName);

            resultBuilder.Replace(match.Value, parameter.Value.ToString());

            if (logBuilder.Length > 1) logBuilder.Append("; ");
            logBuilder.Append($"{parameterName}: {parameter.Value}");
        }

        return new RequestUrlParameterParsingResult(resultBuilder.ToString(), logBuilder.ToString());
    }

    private static KeyValuePair<string, object> TryGetParameter(IRestRequestParameters parameters, string parameterName)
    {
        try
        {
            return parameters.Parameters.First(x => x.Key == parameterName);
        }
        catch (InvalidOperationException)
        {
            throw new ParameterNotFoundException(parameterName);
        }
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

using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BitzArt.Flux.REST;

internal partial class NewFluxRestSetContext<TModel, TKey>(
    IFluxRestSetOptions<TModel> setOptions,
    FluxRestServiceOptions serviceOptions,
    HttpClient httpClient,
    ILogger logger)
    : NewFluxSetContext<TModel, TKey>
     where TModel : class
{
    internal IFluxRestSetOptions<TModel> SetOptions { get; set; } = setOptions;

    internal readonly FluxRestServiceOptions ServiceOptions = serviceOptions;

    internal readonly HttpClient HttpClient = httpClient;

    private readonly ILogger _logger = logger;

    private RequestUrlParameterParsingResult GetEndpointFullPath(FluxRequestParameters? parameters)
    {
        var endpoint = GetEndpoint();
        return GetFullPath(endpoint, true, parameters);
    }

    private RequestUrlParameterParsingResult GetIdEndpointFullPath(TKey? id, FluxRequestParameters? parameters)
    {
        if (SetOptions.IdEndpointOptions.GetPathFunc is not null)
        {
            if (id is null)
            {
                var pathFunc = SetOptions.IdEndpointOptions.GetPathFunc!;
                return GetFullPath(pathFunc(id, parameters?.Parameters), false, parameters);
            }

            if (id is not TKey idCasted) 
                throw new ArgumentException($"Id must be of type {typeof(TKey).Name}.");

            var idEndpoint = SetOptions.IdEndpointOptions.GetPathFunc(idCasted, parameters?.Parameters);
            return GetFullPath(idEndpoint, false, parameters);
        }
        else
        {
            var idEndpoint = SetOptions.EndpointOptions.Path is not null 
                ? Path.Combine(SetOptions.EndpointOptions.Path, id!.ToString()!) 
                : id!.ToString()!;
            
            return GetFullPath(idEndpoint, true, parameters);
        }
    }

    private string GetEndpoint()
    {
        if (SetOptions.EndpointOptions.Path is null) return string.Empty;
        return SetOptions.EndpointOptions.Path;
    }

    private RequestUrlParameterParsingResult GetFullPath(string path, bool handleParameters, FluxRequestParameters? parameters)
    {
        // TODO: Review this condition
        if (ServiceOptions.BaseUrl is null) 
            return new RequestUrlParameterParsingResult(path, string.Empty);

        var baseUrl = ServiceOptions.BaseUrl.TrimEnd('/');
        var localPath = path.TrimStart('/');
        var resultPath = $"{baseUrl}/{localPath}";

        if (handleParameters) 
            return RequestParameterParsingUtility.ParseRequestUrl(resultPath, parameters?.Parameters);

        return new RequestUrlParameterParsingResult(resultPath, string.Empty);
    }

    private async Task<TResult> HandleRequestAsync<TResult>(HttpRequestMessage message, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await HttpClient.SendAsync(message, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new FluxRestNonSuccessStatusCodeException(response);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonSerializer.Deserialize<TResult>(content, ServiceOptions.SerializerOptions)!;

            return result;
        }
        catch (FluxRestException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new FluxRestException("An error has occurred while processing http request. See inner exception for details.", ex);
        }
    }
}

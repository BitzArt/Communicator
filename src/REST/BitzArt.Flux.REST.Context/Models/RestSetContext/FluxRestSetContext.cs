using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey>(
    HttpClient httpClient,
    FluxRestServiceOptions serviceOptions,
    ILogger logger,
    IFluxRestSetOptions<TModel> setOptions)
    : FluxSetContext<TModel, TKey>
     where TModel : class
{
    internal IFluxRestSetOptions<TModel> SetOptions { get; set; } = setOptions;

    internal readonly FluxRestServiceOptions ServiceOptions = serviceOptions;

    internal readonly HttpClient HttpClient = httpClient;

    private readonly ILogger _logger = logger;

    private async Task<TResult> HandleRequestAsync<TResult>(HttpRequestMessage message, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await HttpClient.SendAsync(message, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new FluxRestNonSuccessStatusCodeException(response);

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

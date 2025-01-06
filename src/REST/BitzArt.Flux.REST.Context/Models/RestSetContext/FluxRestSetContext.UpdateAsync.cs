using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace BitzArt.Flux.REST;

internal partial class NewFluxRestSetContext<TModel, TKey> : NewFluxSetContext<TModel, TKey>
    where TModel : class
{
    public override async Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default)
        => await UpdateAsyncInternal<TResponse>(id, model, null, partial, cancellationToken);

    public override async Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        => await UpdateAsyncInternal<TResponse>(id, model, parameters, partial, cancellationToken);

    public override Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default)
        => UpdateAsync<TResponse>(id: default, model, partial, cancellationToken);

    public override Task<TResponse> UpdateAsync<TResponse>(TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        => UpdateAsync<TResponse>(id: default, model, parameters, partial, cancellationToken);

    private async Task<TResponse> UpdateAsyncInternal<TResponse>(TKey? id, TModel model, FluxRequestParameters? parameters, bool partial, CancellationToken cancellationToken)
    {
        var parsed = GetIdEndpointFullPath(id, parameters);
        _logger.LogInformation("Update {type}[{id}]: {route}", typeof(TModel).Name, id is not null ? id.ToString() : "_", parsed.Result);

        var method = partial ? HttpMethod.Patch : HttpMethod.Put;
        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);

        var message = new HttpRequestMessage(method, parsed.Result)
        {
            Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
        };

        var result = await HandleRequestAsync<TResponse>(message, cancellationToken);

        return result;
    }
}

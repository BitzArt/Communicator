using Microsoft.Extensions.Logging;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default)
        => GetAsyncInternal(id, null, cancellationToken);

    public override Task<TModel> GetAsync(TKey? id, FluxRequestParameters parameters, CancellationToken cancellationToken = default)
        => GetAsyncInternal(id, parameters, cancellationToken);

    private async Task<TModel> GetAsyncInternal(TKey? id, FluxRequestParameters? parameters, CancellationToken cancellationToken)
    {
        var parsed = GetIdEndpointFullPath(id, parameters);
        _logger.LogInformation("Get {type}[{id}]: {route}{parsingLog}", typeof(TModel).Name, id!.ToString(), parsed.Result, parsed.Log);

        var message = new HttpRequestMessage(HttpMethod.Get, parsed.Result);
        var result = await HandleRequestAsync<TModel>(message, cancellationToken);

        return result;
    }
}

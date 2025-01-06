using Microsoft.Extensions.Logging;

namespace BitzArt.Flux.REST;

internal partial class NewFluxRestSetContext<TModel, TKey> : NewFluxSetContext<TModel, TKey>
    where TModel : class
{
    public override async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
        => await GetAllAsyncInternal(null, cancellationToken);

    public override async Task<IEnumerable<TModel>> GetAllAsync(FluxRequestParameters parameters, CancellationToken cancellationToken = default)
        => await GetAllAsyncInternal(parameters, cancellationToken);

    private async Task<IEnumerable<TModel>> GetAllAsyncInternal(FluxRequestParameters? parameters, CancellationToken cancellationToken)
    {
        var path = GetEndpointFullPath(parameters);

        _logger.LogInformation("GetAll {type}: {route}{parsingLog}", typeof(TModel).Name, path.Result, path.Log);

        var message = new HttpRequestMessage(HttpMethod.Get, path.Result);
        var result = await HandleRequestAsync<IEnumerable<TModel>>(message, cancellationToken);

        return result;
    }
}

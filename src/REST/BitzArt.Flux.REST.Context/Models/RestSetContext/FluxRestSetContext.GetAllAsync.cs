using Microsoft.Extensions.Logging;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override async Task<IEnumerable<TModel>> GetAllAsync<TParameter>(IRequestParameters<TParameter> parameters, CancellationToken cancellationToken = default)
    {
        var parsed = GetEndpointFullPath(parameters);
        _logger.LogInformation("GetAll {type}: {route}{parsingLog}", typeof(TModel).Name, parsed.Result, parsed.Log);

        var message = new HttpRequestMessage(HttpMethod.Get, parsed.Result);
        var result = await HandleRequestAsync<IEnumerable<TModel>>(message, cancellationToken);

        return result;
    }
}

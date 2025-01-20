using Microsoft.Extensions.Logging;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override async Task<TModel> GetAsync<TParameter>(TKey? id, IRequestParameters<TParameter> parameters, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

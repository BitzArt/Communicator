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
        throw new NotImplementedException();
    }
}

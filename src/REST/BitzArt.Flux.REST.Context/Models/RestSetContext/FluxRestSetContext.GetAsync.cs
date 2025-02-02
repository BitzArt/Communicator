namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
{
    public override Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override async Task<TModel> GetAsync<TInputParameters>(TKey? id, TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

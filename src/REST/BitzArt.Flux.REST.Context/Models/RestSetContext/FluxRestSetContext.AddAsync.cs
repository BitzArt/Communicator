namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
{
    public override async Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override async Task<TResponse> AddAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
      
}

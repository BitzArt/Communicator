namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default)
        => UpdateAsync<TResponse>(id: default, model, partial, cancellationToken);

    public override async Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        => UpdateAsync<TInputParameters, TResponse>(id: default, model, parameters, partial, cancellationToken);

    public override async Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TKey? id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

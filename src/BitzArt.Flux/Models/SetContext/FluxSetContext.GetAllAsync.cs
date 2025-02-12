namespace BitzArt.Flux;

public abstract partial class FluxSetContext<TModel, TKey>
{
    /// <inheritdoc/>
    public abstract Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public abstract Task<IEnumerable<TModel>> GetAllAsync<TInputParameters>(TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

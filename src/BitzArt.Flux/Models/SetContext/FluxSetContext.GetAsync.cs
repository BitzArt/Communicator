namespace BitzArt.Flux;

public abstract partial class FluxSetContext<TModel, TKey>
{
    /// <inheritdoc/>
    public virtual Task<TModel> GetAsync(object id, CancellationToken cancellationToken = default)
        => GetAsync(CastId(id), cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TModel> GetAsync(TKey id, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> GetAsync<TInputParameters>(object id, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?
        => GetAsync(CastId(id), parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TModel> GetAsync<TInputParameters>(TKey id, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

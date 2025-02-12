namespace BitzArt.Flux;

public abstract partial class FluxSetContext<TModel, TKey>
{
    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
        => AddAsync<TModel>(model, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync<TInputParameters>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?
        => AddAsync<TInputParameters, TModel>(model, parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

namespace BitzArt.Flux;

public abstract partial class FluxSetContext<TModel, TKey>
{
    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync(TModel value, CancellationToken cancellationToken = default)
        => AddAsync<TModel>(value, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TResponse>(TModel value, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync<TInputParameters>(TModel value, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters
        => AddAsync<TInputParameters, TModel>(value, parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TInputParameters, TResponse>(TModel value, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters;
}

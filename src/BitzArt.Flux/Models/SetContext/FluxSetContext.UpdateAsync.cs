namespace BitzArt.Flux;

public abstract partial class FluxSetContext<TModel, TKey>
{
    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel>.UpdateAsync(object id, TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(CastId(id), model, partial, cancellationToken);

    Task<TResponse> IFluxSetContext<TModel>.UpdateAsync<TResponse>(object id, TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TResponse>(CastId(id), model, partial, cancellationToken);

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel, TKey>.UpdateAsync(TKey id, TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(id, model, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TResponse>(TKey id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel>.UpdateAsync<TInputParameters>(object id, TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TModel>(CastId(id), model, parameters, partial, cancellationToken);

    Task<TResponse> IFluxSetContext<TModel>.UpdateAsync<TInputParameters, TResponse>(object id, TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TResponse>(CastId(id), model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel, TKey>.UpdateAsync<TInputParameters>(TKey id, TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TModel>(id, model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TKey id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    Task<TModel> IFluxSetContext<TModel>.UpdateAsync(TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(model, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    Task<TModel> IFluxSetContext<TModel>.UpdateAsync<TInputParameters>(TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TModel>(model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

namespace BitzArt.Flux.Sets;

/// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}"/>/>
public interface IFluxSetUpdateOperations<TModel>
{
    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(object id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(object id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TInputParameters>(object id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TInputParameters, TResponse>(object id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TInputParameters>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="IFluxSetUpdateOperations{TModel, TKey}.UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

/// <summary>
/// Allows updating objects in a set.
/// </summary>
/// <typeparam name="TModel">Model type of the set.</typeparam>
/// <typeparam name="TKey">Key type of the set.</typeparam>
public interface IFluxSetUpdateOperations<TModel, TKey>
{
    /// <inheritdoc cref="UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TKey id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TKey id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync{TInputParameters, TResponse}(TKey, TModel, TInputParameters, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TInputParameters>(TKey id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <summary>
    /// Updates an existing object in the set.
    /// </summary>
    /// <typeparam name="TInputParameters">Input parameters type.</typeparam>
    /// <typeparam name="TResponse">Response type.</typeparam>
    /// <param name="id">Unique identifier of the object to update.</param>
    /// <param name="value">The value to update the object with.</param>
    /// <param name="parameters">Parameters used by the operation.</param>
    /// <param name="partial">Whether to perform a partial update (e.g. PATCH in REST).</param>
    /// <param name="cancellationToken">Cancellation token for this operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TKey id, TModel value, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

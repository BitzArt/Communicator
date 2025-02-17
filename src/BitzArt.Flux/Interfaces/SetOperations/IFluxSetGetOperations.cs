namespace BitzArt.Flux.Sets;

/// <inheritdoc cref="IFluxSetGetOperations{TModel,TKey}"/>
public interface IFluxSetGetOperations<TModel>
{
    /// <inheritdoc cref="IFluxSetGetOperations{TModel, TKey}.GetAsync{TInputParameters}(TKey, TInputParameters, CancellationToken)"/>
    public Task<TModel> GetAsync(object id, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetGetOperations{TModel, TKey}.GetAsync{TInputParameters}(TKey, TInputParameters, CancellationToken)"/>
    public Task<TModel> GetAsync<TInputParameters>(object id, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

/// <summary>
/// Allows fetching specific objects from a set.
/// </summary>
/// <typeparam name="TModel">Model type of the set.</typeparam>
/// <typeparam name="TKey">Key type of the set.</typeparam>
public interface IFluxSetGetOperations<TModel, TKey>
{
    /// <inheritdoc cref="GetAsync{TInputParameters}(TKey, TInputParameters, CancellationToken)"/>
    public Task<TModel> GetAsync(TKey id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetches an object from the set.
    /// </summary>
    /// <typeparam name="TInputParameters">Input parameters type.</typeparam>
    /// <param name="id">Unique identifier of the object to fetch.</param>
    /// <param name="parameters">Parameters used by the operation.</param>
    /// <param name="cancellationToken">Cancellation token for this operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task<TModel> GetAsync<TInputParameters>(TKey id, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

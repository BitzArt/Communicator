namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
{
    /// <inheritdoc cref="AddAsync{TInputParameters,TResponse}(TModel, TInputParameters, CancellationToken)"/>
    public Task<TModel> AddAsync(TModel value, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddAsync{TInputParameters,TResponse}(TModel, TInputParameters, CancellationToken)"/>
    public Task<TResponse> AddAsync<TResponse>(TModel value, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddAsync{TInputParameters,TResponse}(TModel, TInputParameters, CancellationToken)"/>
    public Task<TModel> AddAsync<TInputParameters>(TModel value, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <summary>
    /// Adds a new object to the set.
    /// </summary>
    /// <typeparam name="TInputParameters">Input parameters type.</typeparam>
    /// <typeparam name="TResponse">Response type.</typeparam>
    /// <param name="value">The value to add to the set.</param>
    /// <param name="parameters">Parameters used by the operation.</param>
    /// <param name="cancellationToken">Cancellation token for this operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task<TResponse> AddAsync<TInputParameters, TResponse>(TModel value, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

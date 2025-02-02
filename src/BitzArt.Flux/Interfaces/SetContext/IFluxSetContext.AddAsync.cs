namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
{
    /// <summary>
    /// Adds a new object to the set.
    /// </summary>
    public Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddAsync(TModel, CancellationToken)"/>/>
    public Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddAsync(TModel, CancellationToken)"/>/>
    public Task<TModel> AddAsync<TInputParameters>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;

    /// <inheritdoc cref="AddAsync(TModel, CancellationToken)"/>
    public Task<TResponse> AddAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;
}

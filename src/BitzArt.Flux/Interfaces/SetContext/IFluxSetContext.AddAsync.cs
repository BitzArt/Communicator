namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
    where TModel : class
{
    /// <summary>
    /// Adds a new object to the set.
    /// </summary>
    public Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddAsync(TModel, CancellationToken)"/>/>
    public Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddAsync(TModel, CancellationToken)"/>/>
    public Task<TModel> AddAsync(TModel model, IRequestParameters parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddAsync(TModel, CancellationToken)"/>
    public Task<TResponse> AddAsync<TResponse>(TModel model, IRequestParameters parameters, CancellationToken cancellationToken = default);
}

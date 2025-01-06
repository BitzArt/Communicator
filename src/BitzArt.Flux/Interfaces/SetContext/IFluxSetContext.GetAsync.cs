namespace BitzArt.Flux;

public partial interface INewFluxSetContext<TModel>
    where TModel : class
{
    /// <summary>
    /// Fetches a single object from the set by its key.
    /// </summary>
    public Task<TModel> GetAsync(object? id, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetAsync(object?, CancellationToken)"/>
    public Task<TModel> GetAsync(object? id, FluxRequestParameters parameters, CancellationToken cancellationToken = default);
}

public partial interface INewFluxSetContext<TModel, TKey> : INewFluxSetContext<TModel>
    where TModel : class
{
    /// <inheritdoc cref="INewFluxSetContext{TModel}.GetAsync(object?, CancellationToken)"/>
    public Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="INewFluxSetContext{TModel}.GetAsync(object?, FluxRequestParameters, CancellationToken)"/>
    public Task<TModel> GetAsync(TKey? id, FluxRequestParameters parameters, CancellationToken cancellationToken = default);
}

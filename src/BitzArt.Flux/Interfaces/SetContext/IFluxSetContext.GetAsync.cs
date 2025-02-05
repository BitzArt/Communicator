namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
{
    /// <summary>
    /// Fetches a single object from the set by its key.
    /// </summary>
    public Task<TModel> GetAsync(object? id, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetAsync(object?, CancellationToken)"/>
    public Task<TModel> GetAsync<TInputParameters>(object? id, TInputParameters parameters, CancellationToken cancellationToken = default) 
        where TInputParameters : IRequestParameters?;
}

public partial interface IFluxSetContext<TModel, TKey> : IFluxSetContext<TModel>
    where TModel : class
{
    /// <inheritdoc cref="IFluxSetContext{TModel}.GetAsync(object?, CancellationToken)"/>
    public Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetContext{TModel}.GetAsync(object?, CancellationToken)"/>
    public Task<TModel> GetAsync<TInputParameters>(TKey? id, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

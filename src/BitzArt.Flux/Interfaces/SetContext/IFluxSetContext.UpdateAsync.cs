namespace BitzArt.Flux;

public partial interface INewFluxSetContext<TModel>
    where TModel : class
{
    /// <summary>
    /// Updates an object in the set.
    /// </summary>
    public Task<TModel> UpdateAsync(object? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(object? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(object? id, TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, FluxRequestParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(object? id, TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, FluxRequestParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);
}

public partial interface INewFluxSetContext<TModel, TKey> : INewFluxSetContext<TModel>
    where TModel : class
{
    /// <inheritdoc cref="INewFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="INewFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="INewFluxSetContext{TModel}.UpdateAsync(object?, TModel, FluxRequestParameters, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TKey? id, TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="INewFluxSetContext{TModel}.UpdateAsync(object?, TModel, FluxRequestParameters, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, FluxRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);
}

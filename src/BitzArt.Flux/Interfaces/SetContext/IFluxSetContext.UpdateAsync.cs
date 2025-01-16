namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
    where TModel : class
{
    /// <summary>
    /// Updates an object in the set.
    /// </summary>
    public Task<TModel> UpdateAsync(object? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(object? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TParameter>(object? id, TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TParameter, TResponse>(object? id, TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TParameter>(TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TParameter, TResponse>(TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default);
}

public partial interface IFluxSetContext<TModel, TKey> : IFluxSetContext<TModel>
    where TModel : class
{
    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TParameter>(TKey? id, TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TParameter, TResponse>(TKey? id, TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default);
}

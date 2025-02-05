namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
{
    /// <summary>
    /// Updates an object in the set.
    /// </summary>
    public Task<TModel> UpdateAsync(object? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(object? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TInputParameters>(object? id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TInputParameters, TResponse>(object? id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TInputParameters>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

public partial interface IFluxSetContext<TModel, TKey> : IFluxSetContext<TModel>
    where TModel : class
{
    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TModel> UpdateAsync<TInputParameters>(TKey? id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="IFluxSetContext{TModel}.UpdateAsync(object?, TModel, bool, CancellationToken)"/>
    public Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TKey? id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;
}

using BitzArt.Pagination;

namespace BitzArt.Flux;

/// <summary>
/// Flux Set Context base class.
/// </summary>
public abstract class FluxSetContext<TModel, TKey> : IFluxSetContext<TModel, TKey>
    where TModel : class
{
    // ============== GET ALL ==============

    /// <inheritdoc/>
    public abstract Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public abstract Task<IEnumerable<TModel>> GetAllAsync(IRequestParameters parameters, CancellationToken cancellationToken = default);

    // ============== GET PAGE =============

    /// <inheritdoc/>
    public virtual Task<PageResult<TModel>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default)
        => GetPageAsync(new PageRequest(offset, limit), cancellationToken);

    /// <inheritdoc/>
    public abstract Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<PageResult<TModel>> GetPageAsync(int offset, int limit, IRequestParameters parameters, CancellationToken cancellationToken = default)
        => GetPageAsync(new PageRequest(offset, limit), parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, IRequestParameters parameters, CancellationToken cancellationToken = default);

    // ============== GET (Single) =========

    /// <inheritdoc/>
    public virtual Task<TModel> GetAsync(object? id, CancellationToken cancellationToken = default)
    {
        if (id is not TKey idTyped) throw new InvalidOperationException("Invalid key type.");

        return GetAsync(idTyped, cancellationToken);
    }

    /// <inheritdoc/>
    public abstract Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> GetAsync(object? id, IRequestParameters parameters, CancellationToken cancellationToken = default)
    {
        if (id is not TKey idTyped) throw new InvalidOperationException("Invalid key type.");

        return GetAsync(idTyped, parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public abstract Task<TModel> GetAsync(TKey? id, IRequestParameters parameters, CancellationToken cancellationToken = default);

    // ============== ADD ==================

    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
        => AddAsync<TModel>(model, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync(TModel model, IRequestParameters parameters, CancellationToken cancellationToken = default)
        => AddAsync<TModel>(model, parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TResponse>(TModel model, IRequestParameters parameters, CancellationToken cancellationToken = default);

    // ============== UPDATE BY ID =========

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel>.UpdateAsync(object? id, TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(Cast<TKey>(id), model, partial, cancellationToken);

    Task<TResponse> IFluxSetContext<TModel>.UpdateAsync<TResponse>(object? id, TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TResponse>(Cast<TKey>(id), model, partial, cancellationToken);

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel, TKey>.UpdateAsync(TKey? id, TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(id, model, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel>.UpdateAsync(object? id, TModel model, IRequestParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(Cast<TKey>(id), model, parameters, partial, cancellationToken);

    Task<TResponse> IFluxSetContext<TModel>.UpdateAsync<TResponse>(object? id, TModel model, IRequestParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TResponse>(Cast<TKey>(id), model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel, TKey>.UpdateAsync(TKey? id, TModel model, IRequestParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(id, model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, IRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);

    // ============== UPDATE ===============

    Task<TModel> IFluxSetContext<TModel>.UpdateAsync(TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(model, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    Task<TModel> IFluxSetContext<TModel>.UpdateAsync(TModel model, IRequestParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TResponse>(TModel model, IRequestParameters parameters, bool partial = false, CancellationToken cancellationToken = default);

    private static TResult Cast<TResult>(object? value)
    {
        if (value is not TResult casted)
            throw new InvalidOperationException($"Invalid key type. Expected '{typeof(TResult).Name}' but got '{value?.GetType().Name ?? "null"}'.");

        return casted;
    }
}

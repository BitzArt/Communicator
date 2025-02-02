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
    public abstract Task<IEnumerable<TModel>> GetAllAsync<TInputParameters>(TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;

    // ============== GET PAGE =============

    /// <inheritdoc/>
    public virtual Task<PageResult<TModel>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default)
        => GetPageAsync(new PageRequest(offset, limit), cancellationToken);

    /// <inheritdoc/>
    public abstract Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<PageResult<TModel>> GetPageAsync<TInputParameters>(int offset, int limit, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters
        => GetPageAsync(new PageRequest(offset, limit), parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<PageResult<TModel>> GetPageAsync<TInputParameters>(PageRequest pageRequest, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;

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
    public virtual Task<TModel> GetAsync<TInputParameters>(object? id, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters
    {
        if (id is not TKey idTyped) throw new InvalidOperationException("Invalid key type.");

        return GetAsync(idTyped, parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public abstract Task<TModel> GetAsync<TInputParameters>(TKey? id, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;

    // ============== ADD ==================

        /// <inheritdoc/>
    public virtual Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
        => AddAsync<TModel>(model, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync<TInputParameters>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters
        => AddAsync<TInputParameters, TModel>(model, parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;

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
    Task<TModel> IFluxSetContext<TModel>.UpdateAsync<TInputParameters>(object? id, TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TModel>(Cast<TKey>(id), model, parameters, partial, cancellationToken);

    Task<TResponse> IFluxSetContext<TModel>.UpdateAsync<TInputParameters, TResponse>(object? id, TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TResponse>(Cast<TKey>(id), model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    Task<TModel> IFluxSetContext<TModel, TKey>.UpdateAsync<TInputParameters>(TKey? id, TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TModel>(id, model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TKey? id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;

    // ============== UPDATE ===============

    Task<TModel> IFluxSetContext<TModel>.UpdateAsync(TModel model, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TModel>(model, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default);

    Task<TModel> IFluxSetContext<TModel>.UpdateAsync<TInputParameters>(TModel model, TInputParameters parameters, bool partial, CancellationToken cancellationToken)
        => UpdateAsync<TInputParameters, TModel>(model, parameters, partial, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
        where TInputParameters : class, IRequestParameters;

    private static TResult Cast<TResult>(object? value)
    {
        if (value is not TResult casted)
            throw new InvalidOperationException($"Invalid key type. Expected '{typeof(TResult).Name}' but got '{value?.GetType().Name ?? "null"}'.");

        return casted;
    }
}

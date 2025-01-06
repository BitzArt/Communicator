using BitzArt.Pagination;

namespace BitzArt.Flux;

/// <summary>
/// Flux Set Context base class.
/// </summary>
public abstract class NewFluxSetContext<TModel, TKey> : INewFluxSetContext<TModel, TKey>
    where TModel : class
{
    /// <inheritdoc/>
    public abstract Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public abstract Task<IEnumerable<TModel>> GetAllAsync(FluxRequestParameters parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<PageResult<TModel>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default)
        => GetPageAsync(new PageRequest(offset, limit), cancellationToken);

    /// <inheritdoc/>
    public abstract Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<PageResult<TModel>> GetPageAsync(int offset, int limit, FluxRequestParameters parameters, CancellationToken cancellationToken = default)
        => GetPageAsync(new PageRequest(offset, limit), parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, FluxRequestParameters parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> GetAsync(object? id, CancellationToken cancellationToken = default)
    {
        if (id is not TKey idTyped)
            throw new InvalidOperationException("Invalid key type.");

        return GetAsync(idTyped, cancellationToken);
    }

    /// <inheritdoc/>
    public abstract Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> GetAsync(object? id, FluxRequestParameters parameters, CancellationToken cancellationToken = default)
    {
        if (id is not TKey idTyped)
            throw new InvalidOperationException("Invalid key type.");

        return GetAsync(idTyped, parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public abstract Task<TModel> GetAsync(TKey? id, FluxRequestParameters parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
        => AddAsync<TModel>(model, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public virtual Task<TModel> AddAsync(TModel model, FluxRequestParameters parameters, CancellationToken cancellationToken = default)
        => AddAsync<TModel>(model, parameters, cancellationToken);

    /// <inheritdoc/>
    public abstract Task<TResponse> AddAsync<TResponse>(TModel model, FluxRequestParameters parameters, CancellationToken cancellationToken = default);
}

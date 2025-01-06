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
}

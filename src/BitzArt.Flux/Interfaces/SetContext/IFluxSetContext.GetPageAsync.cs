using BitzArt.Pagination;

namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
    where TModel : class
{
    /// <summary>
    /// Fetches a page of objects from the set.
    /// </summary>
    public Task<PageResult<TModel>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(int offset, int limit, IFluxRequestParameters parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, IFluxRequestParameters, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, IFluxRequestParameters parameters, CancellationToken cancellationToken = default);
}

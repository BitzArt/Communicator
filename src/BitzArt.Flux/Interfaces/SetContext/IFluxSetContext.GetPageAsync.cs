using BitzArt.Pagination;

namespace BitzArt.Flux;

public partial interface INewFluxSetContext<TModel>
    where TModel : class
{
    /// <summary>
    /// Fetches a page of objects from the set.
    /// </summary>
    public Task<PageResult<TModel>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(int offset, int limit, FluxRequestParameters parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, FluxRequestParameters, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, FluxRequestParameters parameters, CancellationToken cancellationToken = default);
}

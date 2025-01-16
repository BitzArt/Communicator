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
    public Task<PageResult<TModel>> GetPageAsync(int offset, int limit, IRequestParameters parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, IRequestParameters, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, IRequestParameters parameters, CancellationToken cancellationToken = default);
}

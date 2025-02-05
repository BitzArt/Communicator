using BitzArt.Pagination;

namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
{
    /// <summary>
    /// Fetches a page of objects from the set.
    /// </summary>
    public Task<PageResult<TModel>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync<TInputParameters>(int offset, int limit, TInputParameters parameters, CancellationToken cancellationToken = default)
        where TInputParameters : IRequestParameters?;

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetPageAsync(int, int, CancellationToken)"/>
    public Task<PageResult<TModel>> GetPageAsync<TInputParameters>(PageRequest pageRequest, TInputParameters parameters, CancellationToken cancellationToken = default) 
        where TInputParameters : IRequestParameters?;
}

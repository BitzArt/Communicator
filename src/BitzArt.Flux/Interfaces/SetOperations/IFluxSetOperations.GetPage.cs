using BitzArt.Pagination;

namespace BitzArt.Flux.Sets;

public partial interface IFluxSetOperations
{
    /// <summary>
    /// Allows fetching a page of objects from a set.
    /// </summary>
    /// <typeparam name="TModel">Model type of the set.</typeparam>
    public interface IGetPage<TModel>
    {
        /// <inheritdoc cref="GetPageAsync{TInputParameters}(PageRequest, TInputParameters, CancellationToken)"/>
        public Task<PageResult<TModel>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="GetPageAsync{TInputParameters}(PageRequest, TInputParameters, CancellationToken)"/>
        public Task<PageResult<TModel>> GetPageAsync<TInputParameters>(int offset, int limit, TInputParameters parameters, CancellationToken cancellationToken = default)
            where TInputParameters : IRequestParameters?;

        /// <inheritdoc cref="GetPageAsync{TInputParameters}(PageRequest, TInputParameters, CancellationToken)"/>
        public Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetches a page of objects from the set.
        /// </summary>
        /// <typeparam name="TInputParameters">Input parameters type.</typeparam>
        /// <param name="pageRequest">A <see cref="PageRequest"/> containing page request parameters.</param>
        /// <param name="parameters">Parameters used by the operation.</param>
        /// <param name="cancellationToken">Cancellation token for this operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task<PageResult<TModel>> GetPageAsync<TInputParameters>(PageRequest pageRequest, TInputParameters parameters, CancellationToken cancellationToken = default)
            where TInputParameters : IRequestParameters?;
    }
}

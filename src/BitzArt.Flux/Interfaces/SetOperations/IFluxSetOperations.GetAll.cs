namespace BitzArt.Flux.Sets;

public partial interface IFluxSetOperations
{
    /// <summary>
    /// Allows fetching all objects from the set.
    /// </summary>
    /// <typeparam name="TModel">Model type of the set.</typeparam>
    public interface IGetAll<TModel>
    {
        /// <inheritdoc cref="GetAllAsync{TInputParameters}(TInputParameters,CancellationToken)"/>/>
        public Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetches all objects from the set.
        /// </summary>
        /// <typeparam name="TInputParameters">Input parameters type.</typeparam>
        /// <param name="parameters">Parameters used by the operation.</param>
        /// <param name="cancellationToken">Cancellation token for this operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task<IEnumerable<TModel>> GetAllAsync<TInputParameters>(TInputParameters parameters, CancellationToken cancellationToken = default)
             where TInputParameters : IRequestParameters?;
    }
}

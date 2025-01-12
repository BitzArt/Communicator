namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
    where TModel : class
{
    /// <summary>
    /// Fetches all objects from the set.
    /// </summary>
    public Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetAllAsync(CancellationToken)"/>
    public Task<IEnumerable<TModel>> GetAllAsync(IFluxRequestParameters parameters, CancellationToken cancellationToken = default);
}

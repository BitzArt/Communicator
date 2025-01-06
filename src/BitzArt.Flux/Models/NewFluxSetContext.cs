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
}

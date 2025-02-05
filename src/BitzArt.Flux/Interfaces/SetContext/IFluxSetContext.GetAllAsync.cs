namespace BitzArt.Flux;

public partial interface IFluxSetContext<TModel>
{
    /// <summary>
    /// Fetches all objects from the set.
    /// </summary>
    public Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetAllAsync(CancellationToken)"/>
    public Task<IEnumerable<TModel>> GetAllAsync<TInputParameters>(TInputParameters parameters, CancellationToken cancellationToken = default) 
         where TInputParameters : IRequestParameters?;
}

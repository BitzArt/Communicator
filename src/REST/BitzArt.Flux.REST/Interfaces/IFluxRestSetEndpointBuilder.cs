using BitzArt.Flux.REST;

namespace BitzArt.Flux;

/// <summary>
/// Flux REST set endpoint builder.
/// </summary>
/// /// <typeparam name="TModel">
/// The model type of the set.
/// </typeparam>
/// <typeparam name="TKey">
/// The key type of the set.
/// </typeparam>
public interface IFluxRestSetEndpointBuilder<TModel, TKey> : IFluxRestSetBuilder<TModel, TKey>
    where TModel : class
{
    internal FluxRestSetEndpointOptions<TModel, TKey> EndpointOptions { get; }

    /// <inheritdoc cref="WithParametersExtension.WithParameters{TModel,TKey,TRequestParameters}"/>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TRequestParameters>(
        Func<TRequestParameters, IFluxRequestParameters> getParameters)
        where TRequestParameters : IFluxRequestParameters
        => this.WithParameters<TModel, TKey, TRequestParameters>(getParameters);
}

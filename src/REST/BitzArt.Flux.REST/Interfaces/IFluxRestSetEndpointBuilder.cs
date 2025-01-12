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

    public IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TParameters>(
        Func<TParameters, TParameters> getParameters)
        where TParameters : IFluxRestRequestParameters
        => this.WithParameters<TModel, TKey, TParameters, TParameters>(getParameters);

    /// <inheritdoc cref="WithParametersExtension.WithParameters{TModel,TKey,TRequestParameters}"/>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TInputParameters, TOutputParameters>(
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
        => this.WithParameters<TModel, TKey, TInputParameters, TOutputParameters>(getParameters);

}

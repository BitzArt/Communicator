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

    /// <summary>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TParameters>(
        string endpoint)
        where TParameters : IFluxRequestParameters
        => this.WithEndpoint<TModel, TKey, TParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TParameters>(
        string endpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TParameters : IFluxRequestParameters
        => this.WithEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TInputParameters, TOutputParameters>(
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
        => this.WithEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    ///  <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TParameters>(
        string endpoint)
        where TParameters : IFluxRequestParameters
        => this.WithPageEndpoint<TModel, TKey, TParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    ///  <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TParameters>(
        string endpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TParameters : IFluxRequestParameters
        => this.WithPageEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    ///  <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TInputParameters, TOutputParameters>(
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
        => this.WithPageEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(endpoint, getParameters);
}

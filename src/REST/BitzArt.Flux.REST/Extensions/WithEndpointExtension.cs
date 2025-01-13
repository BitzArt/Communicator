using BitzArt.Flux.REST;

namespace BitzArt.Flux;

/// <summary>
/// Extension methods for configuring the default endpoint of a set.
/// </summary>
public static class WithEndpointExtension
{
    /// <summary>
    /// Configures the default endpoint for the <see cref="IFluxRestSetBuilder{TModel, TKey}"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="IFluxRestSetBuilder{TModel, TKey}"/> with the endpoint configured.
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
        => builder.WithEndpoint<TModel, TKey, FluxRequestParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
        where TParameters : IFluxRequestParameters
    {
        builder.SetOptions.EndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.EndpointOptions.Path = endpoint;
        builder.SetOptions.EndpointOptions.GetRequestParametersFunc = null;

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<FluxRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithEndpoint<TModel, TKey, FluxRequestParameters, FluxRestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TParameters : IFluxRequestParameters
        => builder.WithEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.SetOptions.EndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.EndpointOptions.Path = endpoint;
        builder.SetOptions.EndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }
}

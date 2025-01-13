using BitzArt.Flux.REST;

namespace BitzArt.Flux;

/// <summary>
/// Extension methods for configuring the page endpoint of a set.
/// </summary>
public static class WithPageEndpointExtension
{
    /// <summary>
    /// Configures the page endpoint for the <see cref="IFluxRestSetBuilder{TModel, TKey}"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="IFluxRestSetEndpointBuilder{TModel, TKey}"/> with the page endpoint configured.
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
        => builder.WithPageEndpoint<TModel, TKey, FluxRequestParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
        where TParameters : IFluxRequestParameters
    {
        builder.SetOptions.PageEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.PageEndpointOptions.Path = endpoint;
        builder.SetOptions.PageEndpointOptions.GetRequestParametersFunc = null;

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.PageEndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<FluxRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithPageEndpoint<TModel, TKey, FluxRequestParameters, FluxRestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TParameters : IFluxRequestParameters
        => builder.WithPageEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.SetOptions.PageEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.PageEndpointOptions.Path = endpoint;
        builder.SetOptions.PageEndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.PageEndpointOptions);
    }
}

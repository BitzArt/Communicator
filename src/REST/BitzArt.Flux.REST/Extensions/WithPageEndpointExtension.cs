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
    /// The <see cref="IFluxRestSetBuilder{TModel, TKey}"/> with the page endpoint configured.
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
    {
        var options = new FluxRestSetEndpointOptions<TModel, TKey>(endpoint);
        builder.SetOptions.EndpointOptionsCollection.Add(EndpointType.Page, options);

        return builder;
    }

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
    {
        var options = new FluxRestSetEndpointOptions<TModel, TKey, TParameters>(endpoint, null);
        builder.SetOptions.EndpointOptionsCollection.Add(EndpointType.Page, options);

        return builder;
    }

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<RequestParameters, RestRequestParameters> transformParameters)
        where TModel : class
        => builder.WithPageEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(endpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, RestRequestParameters> transformParameters)
        where TModel : class
        => builder.WithPageEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(endpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<RequestParameters, TOutputParameters> transformParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithPageEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(endpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, TOutputParameters> transformParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
    {
        var options = new FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(endpoint, (parameters) => transformParameters(parameters));
        builder.SetOptions.EndpointOptionsCollection.Add(EndpointType.Page, options);

        return builder;
    }
}

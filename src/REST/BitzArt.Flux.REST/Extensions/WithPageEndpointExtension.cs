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
        => builder.WithPageEndpoint<TModel, TKey, RequestParameters>(endpoint);

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
        where TParameters : IRequestParameters
    {
        builder.SetOptions.PageEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.PageEndpointOptions.Path = endpoint;
        builder.SetOptions.PageEndpointOptions.GetRestRequestParametersFunc = null;

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
        Func<RequestParameters, RestRequestParameters> getParameters)
        where TModel : class
        => builder.WithPageEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, RestRequestParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        => builder.WithPageEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<RequestParameters, TOutputParameters> getParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithPageEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(endpoint, getParameters);

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
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
    {
        builder.SetOptions.PageEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.PageEndpointOptions.Path = endpoint;
        builder.SetOptions.PageEndpointOptions.GetRestRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.PageEndpointOptions);
    }
}

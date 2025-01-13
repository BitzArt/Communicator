using BitzArt.Flux.REST;

namespace BitzArt.Flux;

/// <summary>
/// Extension methods for configuring the page endpoint of a set.
/// </summary>
public static class WithPageEndpointExtension
{
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
    {
        builder.SetOptions.PageEndpointOptions.Path = endpoint;
        builder.SetOptions.PageEndpointOptions.ParametersType = null;

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.PageEndpointOptions);
    }

    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint)
        where TModel : class
        where TParameters : IFluxRequestParameters
    {
        builder.SetOptions.PageEndpointOptions.Path = endpoint;
        builder.SetOptions.PageEndpointOptions.ParametersType = typeof(TParameters);

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.PageEndpointOptions);
    }

    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<FluxRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithPageEndpoint<TModel, TKey, FluxRequestParameters, FluxRestRequestParameters>(endpoint, getParameters);

    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TParameters : IFluxRequestParameters
        => builder.WithPageEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// Configures the page endpoint for the <see cref="IFluxRestSetBuilder{TModel,TKey}"/>
    /// </summary>
    /// <typeparam name="TModel">
    /// The model type of the set.
    /// </typeparam>
    /// <typeparam name="TKey">
    /// The key type of the set.
    /// </typeparam>
    /// <returns>
    /// The <see cref="IFluxRestSetEndpointBuilder{TModel,TKey}"/> with the page endpoint configured
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder, 
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.SetOptions.PageEndpointOptions.Path = endpoint;
        builder.SetOptions.PageEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.PageEndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.PageEndpointOptions);
    }
}

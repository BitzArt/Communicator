using BitzArt.Flux.REST;

namespace BitzArt.Flux;

/// <summary>
/// Extension methods for configuring the Id endpoint in <see cref="IFluxRestSetBuilder{TModel, TKey}"/><br/>
/// The Id endpoint is an endpoint used when fetching an entity by its Id.<br/>
/// Example: /api/entity/1
/// </summary>
public static class WithIdEndpointExtension
{
    /// <summary>
    /// Configures Id endpoint for the <see cref="IFluxRestSetBuilder{TModel,TKey}"/>.<br/>
    /// The Id endpoint is an endpoint used when fetching an entity by its Id.<br/>
    /// Example: /api/entity/1
    /// </summary>
    /// <returns>
    /// The <see cref="IFluxRestSetIdEndpointBuilder{TModel,TKey}"/> with Id endpoint configured
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(this IFluxRestSetBuilder<TModel, TKey> builder, string endpoint)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, FluxRequestParameters>(endpoint);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(this IFluxRestSetBuilder<TModel, TKey> builder, string endpoint)
        where TModel : class
        where TParameters : IFluxRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => endpoint;
        builder.SetOptions.IdEndpointOptions.GetRequestParametersFunc = null;

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, FluxRequestParameters>(getEndpoint);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint)
        where TModel : class
        where TParameters : IFluxRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key);
        builder.SetOptions.IdEndpointOptions.GetRequestParametersFunc = null;

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, FluxRequestParameters, string> getEndpoint)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, FluxRequestParameters>(getEndpoint);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, TParameters, string> getEndpoint)
        where TModel : class
        where TParameters : IFluxRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key, (TParameters)parameters);
        builder.SetOptions.IdEndpointOptions.GetRequestParametersFunc = null;

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<FluxRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, FluxRequestParameters, FluxRestRequestParameters>(endpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TParameters : IFluxRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(endpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => endpoint;
        builder.SetOptions.IdEndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<string> getEndpoint,
        Func<FluxRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, FluxRequestParameters, FluxRestRequestParameters>(getEndpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<string> getEndpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TParameters : IFluxRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(getEndpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint();
        builder.SetOptions.IdEndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<FluxRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, FluxRequestParameters, FluxRestRequestParameters>(getEndpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TParameters : IFluxRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(getEndpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key);
        builder.SetOptions.IdEndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, FluxRequestParameters, string> getEndpoint,
        Func<FluxRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, FluxRequestParameters, FluxRestRequestParameters>(getEndpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, TParameters, string> getEndpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TParameters : IFluxRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TParameters, FluxRestRequestParameters>(getEndpoint, getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, TInputParameters, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key, (TInputParameters)parameters);
        builder.SetOptions.IdEndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }
}

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
    /// Configures Id endpoint for the <see cref="IFluxRestSetBuilder{TModel, TKey}"/>.<br/>
    /// The Id endpoint is an endpoint used when fetching an entity by its Id.<br/>
    /// Example: /api/entity/1
    /// </summary>
    /// <returns>
    /// The <see cref="IFluxRestSetIdEndpointBuilder{TModel, TKey}"/> with Id endpoint configured.
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(this IFluxRestSetBuilder<TModel, TKey> builder, string endpoint)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(this IFluxRestSetBuilder<TModel, TKey> builder, string endpoint)
        where TModel : class
        where TParameters : IRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => endpoint;
        builder.SetOptions.IdEndpointOptions.GetRestRequestParametersFunc = null;

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters>(getEndpoint);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint)
        where TModel : class
        where TParameters : IRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key);
        builder.SetOptions.IdEndpointOptions.GetRestRequestParametersFunc = null;

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, RequestParameters, string> getEndpoint)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters>(getEndpoint);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, TParameters, string> getEndpoint)
        where TModel : class
        where TParameters : IRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key, (TParameters)parameters!);
        builder.SetOptions.IdEndpointOptions.GetRestRequestParametersFunc = null;

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<RequestParameters, RestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, RestRequestParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<RequestParameters, TOutputParameters> getParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => endpoint;
        builder.SetOptions.IdEndpointOptions.GetRestRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<string> getEndpoint,
        Func<RequestParameters, RestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<string> getEndpoint,
        Func<TInputParameters, RestRequestParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<string> getEndpoint,
        Func<RequestParameters, TOutputParameters> getParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint();
        builder.SetOptions.IdEndpointOptions.GetRestRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<RequestParameters, RestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<TInputParameters, RestRequestParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<RequestParameters, TOutputParameters> getParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key);
        builder.SetOptions.IdEndpointOptions.GetRestRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, RequestParameters, string> getEndpoint,
        Func<RequestParameters, RestRequestParameters> getParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, TInputParameters, string> getEndpoint,
        Func<TInputParameters, RestRequestParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, RequestParameters, string> getEndpoint,
        Func<RequestParameters, TOutputParameters> getParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, TInputParameters, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
    {
        builder.SetOptions.IdEndpointOptions.ParametersType = typeof(TInputParameters);
        builder.SetOptions.IdEndpointOptions.GetPathFunc = (key, parameters) => getEndpoint((TKey?)key, (TInputParameters)parameters!);
        builder.SetOptions.IdEndpointOptions.GetRestRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return new FluxRestSetIdEndpointBuilder<TModel, TKey>(builder, (FluxRestSetIdEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }
}

﻿using BitzArt.Flux.REST;

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
    /// The <see cref="IFluxRestSetBuilder{TModel, TKey}"/> with Id endpoint configured.
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(this IFluxRestSetBuilder<TModel, TKey> builder, string endpoint)
        where TModel : class
    {
        var options = new FluxRestSetIdEndpointOptions<TModel, TKey>(endpoint, (key) => endpoint);
        builder.SetOptions.EndpointOptionsCollection.Add(FluxRestSetEndpointOptionsType.IdEndpoint, options);

        return builder;
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(this IFluxRestSetBuilder<TModel, TKey> builder, string endpoint)
        where TModel : class
    {
        var options = new FluxRestSetIdEndpointOptions<TModel, TKey, TParameters>(endpoint, (key) => endpoint);
        builder.SetOptions.EndpointOptionsCollection.Add(FluxRestSetEndpointOptionsType.IdEndpoint, options);

        return builder;
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint)
        where TModel : class
    {
        var options = new FluxRestSetIdEndpointOptions<TModel, TKey>(null, getEndpoint);
        builder.SetOptions.EndpointOptionsCollection.Add(FluxRestSetEndpointOptionsType.IdEndpoint, options);
        
        return builder;
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint)
        where TModel : class
    {
        var options = new FluxRestSetIdEndpointOptions<TModel, TKey, TParameters>(null, getEndpoint);
        builder.SetOptions.EndpointOptionsCollection.Add(FluxRestSetEndpointOptionsType.IdEndpoint, options);

        return builder;
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<RequestParameters, RestRequestParameters> transformParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(endpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, RestRequestParameters> transformParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(endpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<RequestParameters, TOutputParameters> transformParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(endpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        string endpoint,
        Func<TInputParameters, TOutputParameters> transformParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
    {
        var options = new FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>(endpoint, (key) => endpoint, (parameters) => transformParameters(parameters));
        builder.SetOptions.EndpointOptionsCollection.Add(FluxRestSetEndpointOptionsType.IdEndpoint, options);

        return builder;
    }

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<RequestParameters, RestRequestParameters> transformParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, RestRequestParameters>(getEndpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<TInputParameters, RestRequestParameters> transformParameters)
        where TModel : class
        => builder.WithIdEndpoint<TModel, TKey, TInputParameters, RestRequestParameters>(getEndpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<RequestParameters, TOutputParameters> transformParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
        => builder.WithIdEndpoint<TModel, TKey, RequestParameters, TOutputParameters>(getEndpoint, transformParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public static IFluxRestSetBuilder<TModel, TKey> WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetBuilder<TModel, TKey> builder,
        Func<TKey?, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> transformParameters)
        where TModel : class
        where TOutputParameters : IRestRequestParameters
    {
        var options = new FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>(null, getEndpoint, (parameters) => transformParameters(parameters));
        builder.SetOptions.EndpointOptionsCollection.Add(FluxRestSetEndpointOptionsType.IdEndpoint, options);

        return builder;
    }
}

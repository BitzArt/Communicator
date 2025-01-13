﻿using BitzArt.Flux.REST;

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
public interface IFluxRestSetIdEndpointBuilder<TModel, TKey> : IFluxRestSetBuilder<TModel, TKey>
    where TModel : class
{
    internal FluxRestSetIdEndpointOptions<TModel, TKey> EndpointOptions { get; }

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(string endpoint)
        where TParameters : IFluxRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(endpoint);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<TKey?, string> getEndpoint)
        where TParameters : IFluxRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(Func<TKey?, TParameters, string> getEndpoint)
        where TParameters : IFluxRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        string endpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TParameters : IFluxRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(endpoint, getParameters);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(endpoint, getParameters);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<string> getEndpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TParameters : IFluxRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint, getParameters);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        Func<string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(getEndpoint, getParameters);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<TKey?, string> getEndpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TParameters : IFluxRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint, getParameters);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        Func<TKey?, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(getEndpoint, getParameters);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<TKey?, TParameters, string> getEndpoint,
        Func<TParameters, FluxRestRequestParameters> getParameters)
        where TParameters : IFluxRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint, getParameters);

    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        Func<TKey?, TInputParameters, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(getEndpoint, getParameters);
}

﻿using BitzArt.Flux.REST;
using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Flux;

internal class FluxRestSetIdEndpointBuilder<TModel, TKey, TInputParameters>(
    IFluxRestSetBuilder<TModel, TKey> setBuilder,
    FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters> endpointOptions)
    : IFluxRestSetIdEndpointBuilder<TModel, TKey, TInputParameters>
    where TModel : class
{
    public IFluxRestSetBuilder<TModel, TKey> SetBuilder { get; private set; } = setBuilder;

    public FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters> EndpointOptions => endpointOptions;

    public IServiceCollection Services => SetBuilder.Services;

    public IFluxServiceFactory ServiceFactory => SetBuilder.ServiceFactory;

    public IFluxFactory Factory => SetBuilder.Factory;

    IFluxRestSetOptions<TModel> IFluxRestSetBuilder<TModel, TKey>.SetOptions => SetBuilder.SetOptions;

    FluxRestServiceOptions IFluxRestServiceBuilder.ServiceOptions => SetBuilder.ServiceOptions;

    Action<IServiceProvider, HttpClient>? IFluxRestServiceBuilder.HttpClientConfiguration
    {
        get => SetBuilder.HttpClientConfiguration;
        set => SetBuilder.HttpClientConfiguration = value;
    }
}

internal class FluxRestSetIdEndpointBuilder<TModel, TKey>(
    IFluxRestSetBuilder<TModel, TKey> setBuilder,
    FluxRestSetIdEndpointOptions<TModel, TKey> endpointOptions)
    : IFluxRestSetIdEndpointBuilder<TModel, TKey>
    where TModel : class
{
    public IFluxRestSetBuilder<TModel, TKey> SetBuilder { get; private set; } = setBuilder;

    public FluxRestSetIdEndpointOptions<TModel, TKey> EndpointOptions { get; private set; } = endpointOptions;

    public IServiceCollection Services => SetBuilder.Services;

    public IFluxServiceFactory ServiceFactory => SetBuilder.ServiceFactory;

    public IFluxFactory Factory => SetBuilder.Factory;

    IFluxRestSetOptions<TModel> IFluxRestSetBuilder<TModel, TKey>.SetOptions => SetBuilder.SetOptions;

    FluxRestServiceOptions IFluxRestServiceBuilder.ServiceOptions => SetBuilder.ServiceOptions;

    Action<IServiceProvider, HttpClient>? IFluxRestServiceBuilder.HttpClientConfiguration
    {
        get => SetBuilder.HttpClientConfiguration;
        set => SetBuilder.HttpClientConfiguration = value;
    }
}

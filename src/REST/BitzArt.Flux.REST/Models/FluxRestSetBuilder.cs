﻿using BitzArt.Flux.REST;
using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Flux;

internal class FluxRestSetBuilder<TModel>(IFluxRestServiceBuilder serviceBuilder, string? path)
    : FluxRestSetBuilder<TModel, object>(serviceBuilder, path)
    where TModel : class
{
}

internal class FluxRestSetBuilder<TModel, TKey>(IFluxRestServiceBuilder serviceBuilder, string? path) : IFluxRestSetBuilder<TModel, TKey>
    where TModel : class
{
    public FluxRestSetOptions<TModel, TKey> SetOptions { get; set; } = new(serviceBuilder.ServiceOptions, path);
    IFluxRestSetOptions<TModel> IFluxRestSetBuilder<TModel, TKey>.SetOptions => SetOptions;

    public IFluxRestServiceBuilder ServiceBuilder { get; init; } = serviceBuilder;

    public IServiceCollection Services => ServiceBuilder.Services;
    public IFluxServiceFactory ServiceFactory => ServiceBuilder.ServiceFactory;
    public IFluxFactory Factory => ServiceBuilder.Factory;
    public FluxRestServiceOptions ServiceOptions => ServiceBuilder.ServiceOptions;

    public Action<IServiceProvider, HttpClient>? HttpClientConfiguration
    {
        get => ServiceBuilder.HttpClientConfiguration;
        set => ServiceBuilder.HttpClientConfiguration = value;
    }
}

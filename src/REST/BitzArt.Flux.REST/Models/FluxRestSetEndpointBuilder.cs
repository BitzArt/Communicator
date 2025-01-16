using BitzArt.Flux.REST;
using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Flux;

internal class FluxRestSetEndpointBuilder<TModel, TKey, TInputParameters>(
    IFluxRestSetBuilder<TModel, TKey> setBuilder,
    FluxRestSetEndpointOptions<TModel, TKey, TInputParameters> endpointOptions)
    : FluxRestSetEndpointBuilder<TModel, TKey>(setBuilder, endpointOptions), IFluxRestSetEndpointBuilder<TModel, TKey, TInputParameters>
    where TModel : class
{
    public new FluxRestSetEndpointOptions<TModel, TKey, TInputParameters> EndpointOptions => _endpointOptions;

    private FluxRestSetEndpointOptions<TModel, TKey, TInputParameters> _endpointOptions = endpointOptions;

    private protected override FluxRestSetEndpointOptions<TModel, TKey> GetEndpointOptionsBase() => _endpointOptions;
}

internal class FluxRestSetEndpointBuilder<TModel, TKey>(
    IFluxRestSetBuilder<TModel, TKey> setBuilder,
    FluxRestSetEndpointOptions<TModel, TKey> endpointOptions)
    : IFluxRestSetEndpointBuilder<TModel, TKey>
    where TModel : class
{
    public IFluxRestSetBuilder<TModel, TKey> SetBuilder { get; private set; } = setBuilder;

    public FluxRestSetEndpointOptions<TModel, TKey> EndpointOptions => GetEndpointOptionsBase();

    private protected virtual FluxRestSetEndpointOptions<TModel, TKey> GetEndpointOptionsBase() => _endpointOptions;

    private FluxRestSetEndpointOptions<TModel, TKey> _endpointOptions = endpointOptions;

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

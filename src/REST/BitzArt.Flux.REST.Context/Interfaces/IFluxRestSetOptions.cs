namespace BitzArt.Flux.REST;

internal interface IFluxRestSetOptions<TModel>
    where TModel : class
{
    public IFluxRestSetEndpointOptions<TModel> EndpointOptions { get; }

    // TODO: IFluxRestSetPageEndpointOptions<TModel> 
    // See: https://github.com/BitzArt/Flux/issues/4
    public IFluxRestSetEndpointOptions<TModel> PageEndpointOptions { get; }

    public IFluxRestSetIdEndpointOptions<TModel> IdEndpointOptions { get; }

    internal Type? KeyType { get; }
}

namespace BitzArt.Flux.REST;

internal interface IFluxRestSetOptions<TModel>
    where TModel : class
{
    public IFluxRestSetEndpointOptions<TModel> EndpointOptions { get; set; }

    // TODO: IFluxRestSetPageEndpointOptions<TModel> 
    // See: https://github.com/BitzArt/Flux/issues/4
    public IFluxRestSetEndpointOptions<TModel> PageEndpointOptions { get; set; }

    public IFluxRestSetIdEndpointOptions<TModel> IdEndpointOptions { get; set; }

    internal Type? KeyType { get; }
}

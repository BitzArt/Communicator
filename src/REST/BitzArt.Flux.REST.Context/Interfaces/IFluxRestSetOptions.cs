namespace BitzArt.Flux.REST;

internal interface IFluxRestSetOptions<TModel>
    where TModel : class
{
    public IFluxRestSetEndpointCollection<TModel> EndpointCollection { get; }

    internal Type? KeyType { get; }
}

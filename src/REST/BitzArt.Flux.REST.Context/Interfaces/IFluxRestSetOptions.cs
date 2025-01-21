namespace BitzArt.Flux.REST;

internal interface IFluxRestSetOptions<TModel>
    where TModel : class
{
    public IFluxRestSetEndpointOptionsCollection<TModel> EndpointOptionsCollection { get; }

    internal Type? KeyType { get; }
}

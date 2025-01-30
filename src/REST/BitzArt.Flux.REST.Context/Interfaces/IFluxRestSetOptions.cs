namespace BitzArt.Flux.REST;

internal interface IFluxRestSetOptions<TModel>
    where TModel : class
{
    public IFluxRestSetEndpointsCollection<TModel> EndpointsCollection { get; }

    internal Type? KeyType { get; }
}

namespace BitzArt.Flux.REST;

internal class FluxRestSetOptions<TModel, TKey> : IFluxRestSetOptions<TModel>
    where TModel : class
{
    public FluxRestSetEndpointOptionsCollection<TModel, TKey> EndpointOptionsCollection { get; private set; }

    IFluxRestSetEndpointOptionsCollection<TModel> IFluxRestSetOptions<TModel>.EndpointOptionsCollection => EndpointOptionsCollection;

    public Type? KeyType => typeof(TKey);

    public FluxRestSetOptions()
    {
        EndpointOptionsCollection = new();
    }
}
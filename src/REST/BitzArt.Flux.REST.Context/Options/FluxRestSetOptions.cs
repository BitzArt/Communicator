namespace BitzArt.Flux.REST;

internal class FluxRestSetOptions<TModel, TKey> : IFluxRestSetOptions<TModel>
    where TModel : class
{
    public FluxRestSetEndpointOptionsCollection<TModel, TKey> EndpointOptionsCollection { get; } = new();

    IFluxRestSetEndpointOptionsCollection<TModel> IFluxRestSetOptions<TModel>.EndpointOptionsCollection => EndpointOptionsCollection;

    public Type? KeyType => typeof(TKey);
}
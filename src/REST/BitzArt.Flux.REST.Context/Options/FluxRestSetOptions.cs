namespace BitzArt.Flux.REST;

internal class FluxRestSetOptions<TModel, TKey> : IFluxRestSetOptions<TModel>
    where TModel : class
{
    public FluxRestSetEndpointCollection<TModel, TKey> EndpointCollection { get; } = new();

    IFluxRestSetEndpointCollection<TModel> IFluxRestSetOptions<TModel>.EndpointCollection => EndpointCollection;

    public Type? KeyType => typeof(TKey);
}
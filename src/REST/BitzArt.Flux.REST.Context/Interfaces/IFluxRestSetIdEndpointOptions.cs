namespace BitzArt.Flux.REST;

internal interface IFluxRestSetIdEndpointOptions<TModel> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    public Func<object?, IFluxRequestParameters?, string>? GetPathFunc { get; set; }
}

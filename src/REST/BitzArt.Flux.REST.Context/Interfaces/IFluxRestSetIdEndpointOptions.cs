namespace BitzArt.Flux.REST;

internal interface IFluxRestSetIdEndpointOptions<TModel> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    public Func<object?, IRequestParameters?, string>? GetPathFunc { get; set; }
}

namespace BitzArt.Flux.REST;

internal class FluxRestSetPageEndpointOptions<TModel, TKey, TInputParameters>(
    string? path = null, 
    Func<TInputParameters?, IRestRequestParameters>? transformParameters = null)
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(path, transformParameters), IFluxRestSetPageEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
}

namespace BitzArt.Flux.REST;

internal interface IFluxRestSetPageEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>, IFluxRestSetPageEndpointOptions<TModel>
    where TModel : class
{
}

internal interface IFluxRestSetPageEndpointOptions<TModel> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
}

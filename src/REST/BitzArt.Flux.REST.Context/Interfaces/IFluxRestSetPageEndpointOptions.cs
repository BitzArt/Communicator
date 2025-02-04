namespace BitzArt.Flux.REST;

internal interface IFluxRestSetPageEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
}

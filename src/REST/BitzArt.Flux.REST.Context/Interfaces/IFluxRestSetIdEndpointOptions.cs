namespace BitzArt.Flux.REST;

internal interface IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    public IGetPathByIdFunc GetPathFunc { get; set; }
}

namespace BitzArt.Flux.REST;

internal interface IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    public IGetPathByIdFunc GetPathFunc { get; set; }
}

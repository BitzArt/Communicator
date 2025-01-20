namespace BitzArt.Flux.REST;

internal interface IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel>, IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    public IGetPathByIdFunc GetPathFunc { get; set; }
}

internal interface IFluxRestSetIdEndpointOptions<TModel> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    public IGetPathByIdFunc GetPathFunc { get; set; } 
}

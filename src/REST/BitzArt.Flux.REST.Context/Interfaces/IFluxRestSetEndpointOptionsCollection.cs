namespace BitzArt.Flux.REST;

internal interface IFluxRestSetEndpointOptionsCollection<TModel>
    where TModel : class
{
    public ICollection<IFluxRestSetEndpointOptions<TModel>> EndpointOptions { get; }

    // TODO:  ICollection<IFluxRestSetPageEndpointOptions<TModel>> 
    // See: https://github.com/BitzArt/Flux/issues/4
    public ICollection<IFluxRestSetEndpointOptions<TModel>> PageEndpointOptions { get; }

    public ICollection<IFluxRestSetIdEndpointOptions<TModel>> IdEndpointOptions { get; }

    public IFluxRestSetEndpointOptions<TModel, TInputParameters> Get<TInputParameters>(FluxRestSetEndpointOptionsType type);

    public IFluxRestSetEndpointOptions<TModel> Get(FluxRestSetEndpointOptionsType type, Type inputParametersType); 

    public void Add<TInputParameters>(FluxRestSetEndpointOptionsType type, IFluxRestSetEndpointOptions<TModel, TInputParameters> endpointOptions);
}

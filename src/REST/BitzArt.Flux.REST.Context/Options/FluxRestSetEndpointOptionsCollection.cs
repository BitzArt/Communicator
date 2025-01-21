namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptionsCollection<TModel, TKey> : IFluxRestSetEndpointOptionsCollection<TModel>
    where TModel : class
{
    public ICollection<IFluxRestSetEndpointOptions<TModel>> EndpointOptions { get; } = [];

    public ICollection<IFluxRestSetEndpointOptions<TModel>> PageEndpointOptions { get; } = [];

    public ICollection<IFluxRestSetIdEndpointOptions<TModel>> IdEndpointOptions { get; } = [];

    public IFluxRestSetEndpointOptions<TModel, TInputParameters> Get<TInputParameters>(FluxRestSetEndpointOptionsType type)
    {
        throw new NotImplementedException();
    }

    public IFluxRestSetEndpointOptions<TModel> Get(FluxRestSetEndpointOptionsType type, Type inputParametersType)
    {
        throw new NotImplementedException();
    }
}

namespace BitzArt.Flux.REST;

/// <summary>
/// Represents a collection of endpoint options for a set of endpoints. <br/>
/// Endpoint is defined by it's <see cref="EndpointType"/> and the type of the input parameters.
/// </summary>
/// <typeparam name="TModel"></typeparam>
internal interface IFluxRestSetEndpointOptionsCollection<TModel>
    where TModel : class
{
    public IFluxRestSetEndpointOptions<TModel, TInputParameters> Get<TInputParameters>(EndpointType type);

    public IFluxRestSetEndpointOptions<TModel> Get(EndpointType type, Type? inputParametersType = null);

    public void Add<TOptions>(TOptions options)
        where TOptions : IFluxRestSetEndpointOptions<TModel>;
}

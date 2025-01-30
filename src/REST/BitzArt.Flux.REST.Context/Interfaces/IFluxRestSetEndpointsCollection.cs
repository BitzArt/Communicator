using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

/// <summary>
/// Represents a collection of endpoint options for a set of endpoints.<br/>
/// Endpoint is defined by it's <see cref="EndpointType"/> and the type of the input parameters.
/// </summary>
/// <typeparam name="TModel"></typeparam>
internal interface IFluxRestSetEndpointsCollection<TModel>
    where TModel : class
{
    public HttpRequestMessage Resolve(EndpointType endpointType, Func<string, HttpRequestMessage> configureRequestMessage);

    public HttpRequestMessage Resolve<TParameter>(EndpointType endpointType, IRequestParameters<TParameter> requestParameters, Func<string, HttpRequestMessage> configureRequestMessage);

    public HttpRequestMessage Resolve<TInputParameters, TKey>(
        EndpointType endpointType,
        TInputParameters? requestParameters = null,
        TKey? id = default,
        PageRequest? pageRequest = null,
        Func<string, HttpRequestMessage> configureRequestMessage) 
        where TInputParameters : class;

    public void Add<TInputParameters>(IFluxRestSetEndpointOptions<TModel, TInputParameters> endpointOptions);
}

using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

/// <summary>
/// Represents a collection of endpoint options for a set of endpoints.<br/>
/// Endpoint is defined by it's <see cref="EndpointType"/> and the type of the input parameters.
/// </summary>
/// <typeparam name="TModel"></typeparam>
internal interface IFluxRestSetEndpointCollection<TModel>
    where TModel : class
{
    public HttpRequestMessage Resolve<TInputParameters, TKey>(
        EndpointType endpointType,
        TInputParameters? requestParameters = default,
        TKey? id = default,
        PageRequest? pageRequest = null,
        Func<string, HttpRequestMessage>? createRequestMessage = null) 
        where TInputParameters : IRequestParameters?;

    public void Add<TInputParameters>(IFluxRestSetEndpointOptions<TModel, TInputParameters> endpointOptions)
        where TInputParameters : IRequestParameters?;
}

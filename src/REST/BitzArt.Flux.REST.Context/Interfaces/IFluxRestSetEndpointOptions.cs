using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

internal interface IFluxRestSetEndpointOptions<TModel, TInputParameters> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    public Func<TInputParameters, IRestRequestParameters>? TransformParametersFunc { get; internal set; }
}

internal interface IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <summary>
    /// A path to the endpoint.
    /// Can be null if other approach to building the endpoint path is used.
    /// </summary>
    public string? Path { get; internal set; }

    public HttpRequestMessage PrepareRequest(IRequestPreparationParameters parameters);
}

internal class RequestPreparationParameters<TInputParameters, TKey> : IRequestPreparationParameters
    where TInputParameters : class, IRequestParameters
{
    public EndpointType EndpointType { get; set; }

    public TInputParameters? RequestParameters { get; set; }

    object? IRequestPreparationParameters.RequestParameters => RequestParameters;

    public TKey? Id { get; set; }

    object? IRequestPreparationParameters.Id => Id;

    public PageRequest? PageRequest { get; set; }

    public Func<string, HttpRequestMessage> InitialCreateRequestMessageFunc { get; set; }

    public RequestPreparationParameters(
        EndpointType endpointType,
        TInputParameters? requestParameters, 
        TKey? id, 
        PageRequest? pageRequest, 
        Func<string, HttpRequestMessage> initialCreateRequestMessageFunc)
    {
        EndpointType = endpointType;
        RequestParameters = requestParameters;
        Id = id;
        PageRequest = pageRequest;
        InitialCreateRequestMessageFunc = initialCreateRequestMessageFunc;
    }
}

internal interface IRequestPreparationParameters
{
    EndpointType EndpointType { get; }

    public object? RequestParameters { get; }

    public object? Id { get;}

    public PageRequest? PageRequest { get; }

    public Func<string, HttpRequestMessage> InitialCreateRequestMessageFunc { get; }
}

using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

internal class RequestPreparationParameters<TInputParameters, TKey>(
    EndpointType endpointType,
    TInputParameters? requestParameters,
    TKey? id,
    PageRequest? pageRequest,
    Func<string, HttpRequestMessage>? initialCreateRequestMessageFunc) 
    : IRequestPreparationParameters
    where TInputParameters : IRequestParameters?
{
    public EndpointType EndpointType { get; set; } = endpointType;

    public TInputParameters? RequestParameters { get; set; } = requestParameters;

    object? IRequestPreparationParameters.RequestParameters => RequestParameters;

    public TKey? Id { get; set; } = id;

    object? IRequestPreparationParameters.Id => Id;

    public PageRequest? PageRequest { get; set; } = pageRequest;

    public Func<string, HttpRequestMessage>? InitialCreateRequestMessageFunc { get; set; } = initialCreateRequestMessageFunc;
}

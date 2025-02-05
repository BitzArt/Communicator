﻿using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

internal class RequestPreparationParameters<TInputParameters, TKey> : IRequestPreparationParameters
    where TInputParameters : IRequestParameters?
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
        TKey? id, 
        TInputParameters? requestParameters, 
        Func<string, HttpRequestMessage> initialCreateRequestMessageFunc) 
        : this(endpointType, requestParameters, initialCreateRequestMessageFunc)
    {
        Id = id;
    }

    public RequestPreparationParameters(
        EndpointType endpointType, 
        PageRequest? pageRequest, 
        TInputParameters? requestParameters, 
        Func<string, HttpRequestMessage> initialCreateRequestMessageFunc)
        : this(endpointType, requestParameters, initialCreateRequestMessageFunc)
    {
        PageRequest = pageRequest;
    }

    public RequestPreparationParameters(
    EndpointType endpointType,
    TInputParameters? requestParameters,
    Func<string, HttpRequestMessage> initialCreateRequestMessageFunc)
    {
        EndpointType = endpointType;
        RequestParameters = requestParameters;
        InitialCreateRequestMessageFunc = initialCreateRequestMessageFunc;
    }
}

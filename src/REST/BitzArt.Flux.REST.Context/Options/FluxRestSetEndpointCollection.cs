namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointCollection<TModel, TKey> : IFluxRestSetEndpointCollection<TModel>
    where TModel : class
{
    private readonly Dictionary<EndpointSignature, IFluxRestSetEndpointOptions<TModel>> _values = [];

    public void Add<TInputParameters>(IFluxRestSetEndpointOptions<TModel, TInputParameters> endpointOptions)
        where TInputParameters : class, IRequestParameters
    {
        switch (endpointOptions)
        {
            case IFluxRestSetIdEndpointOptions<TModel, TInputParameters> idEndpointOptions:
                Add(EndpointType.Id, idEndpointOptions);
                break;
            case IFluxRestSetPageEndpointOptions<TModel, TInputParameters> pageEnpointOptions:
                Add(EndpointType.Page, pageEnpointOptions);
                break;
            case IFluxRestSetEndpointOptions<TModel, TInputParameters> defaultEndpointOptions:
                Add(EndpointType.Default, defaultEndpointOptions);
                break;
            default:
                throw new InvalidOperationException($"Unknown endpoint options type '{endpointOptions.GetType()}'.");
        }
    }

    private void Add<TInputParameters>(EndpointType endpointType, IFluxRestSetEndpointOptions<TModel, TInputParameters> endpointOptions)
        where TInputParameters: class, IRequestParameters
    {
        var inputParametersType = typeof(TInputParameters);
        var signature = new EndpointSignature(endpointType, inputParametersType);

        if (!_values.TryAdd(signature, endpointOptions))
            throw new InvalidOperationException($"Options for endpoint type '{endpointType}' and input parameters type '{inputParametersType}' already registered.");

        var inputParametersUnderlyingType = Nullable.GetUnderlyingType(inputParametersType);

        // The type of input parameters is nullable. 
        // Register endpoint options for the underlying type as well.
        if (inputParametersUnderlyingType is not null)
        {
            var underlyingTypeSignature = new EndpointSignature(endpointType, inputParametersUnderlyingType);
            if (!_values.TryAdd(underlyingTypeSignature, endpointOptions))
                throw new InvalidOperationException($""); // TODO: add exception message
        }
    }

    public HttpRequestMessage Resolve<TInputParameters, TKey>(
        EndpointType endpointType,
        IRequestPreparationParameters parameters)
        where TInputParameters : class, IRequestParameters
    {
        var endpointOptions = ResolveOptions<TInputParameters>(endpointType)!;
        HttpRequestMessage requestMessage = endpointOptions.PrepareRequest(parameters);

        return requestMessage;
    }

    private IFluxRestSetEndpointOptions<TModel, TInputParameters> ResolveOptions<TInputParameters>(EndpointType endpointType)
        where TInputParameters : class, IRequestParameters
    {
        var inputParametersType = typeof(TInputParameters);
        var signature = new EndpointSignature(endpointType, inputParametersType);

        if (_values.TryGetValue(signature, out var endpointOptions))
            return (IFluxRestSetEndpointOptions<TModel, TInputParameters>)endpointOptions;

        var a = "";
        var b = string.Empty;

        return GetDefaultEndpointOptions<TInputParameters>();
    }

    private IFluxRestSetEndpointOptions<TModel, TInputParameters> GetDefaultEndpointOptions<TInputParameters>()
        where TInputParameters : IRequestParameters
    {
        return new FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>();
    }

    private record EndpointSignature(EndpointType EndpointType, Type? InputParametersType);
}

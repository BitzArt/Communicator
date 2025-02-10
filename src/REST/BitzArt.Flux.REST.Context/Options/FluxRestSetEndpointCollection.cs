namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointCollection<TModel, TKey>(IFluxRestSetOptions<TModel> setOptions) 
    : IFluxRestSetEndpointCollection<TModel>
    where TModel : class
{
    private readonly Dictionary<EndpointSignature, IFluxRestSetEndpointOptions<TModel>> _values = [];

    public IFluxRestSetOptions<TModel> SetOptions { get; } = setOptions;

    public void Add<TInputParameters>(IFluxRestSetEndpointOptions<TModel, TInputParameters> endpointOptions)
        where TInputParameters : IRequestParameters?
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
        where TInputParameters: IRequestParameters?
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

    public HttpRequestMessage Resolve<TInputParameters>(IRequestPreparationParameters parameters)
        where TInputParameters : IRequestParameters?
    {
        var endpointOptions = ResolveOptions<TInputParameters>(parameters.EndpointType);
        var requestMessage = endpointOptions.PrepareRequest(parameters);

        return requestMessage;
    }

    private IFluxRestSetEndpointOptions<TModel, TInputParameters> ResolveOptions<TInputParameters>(EndpointType endpointType)
        where TInputParameters : IRequestParameters?
    {
        var inputParametersType = typeof(TInputParameters);
        var signature = new EndpointSignature(endpointType, inputParametersType);

        if (_values.TryGetValue(signature, out var endpointOptions))
            return (IFluxRestSetEndpointOptions<TModel, TInputParameters>)endpointOptions;

        return GetDefaultEndpointOptions<TInputParameters>(endpointType);
    }

    private FluxRestSetEndpointOptions<TModel, TKey, TInputParameters> GetDefaultEndpointOptions<TInputParameters>(EndpointType endpointType)
        where TInputParameters : IRequestParameters?
    {
        return endpointType switch
        {
            EndpointType.Id => FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>.GetDefaultInstance(SetOptions),
            EndpointType.Page => FluxRestSetPageEndpointOptions<TModel, TKey, TInputParameters>.GetDefaultInstance(SetOptions),
            EndpointType.Default => FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>.GetDefaultInstance(SetOptions),
            _ => throw new InvalidOperationException($"Unknown endpoint type '{endpointType}'."),
        };
    }

    private record EndpointSignature(EndpointType EndpointType, Type InputParametersType);
}

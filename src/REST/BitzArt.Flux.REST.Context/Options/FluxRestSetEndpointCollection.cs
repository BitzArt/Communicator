namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointCollection<TModel, TKey>(IFluxRestSetOptions<TModel> setOptions) 
    : IFluxRestSetEndpointCollection<TModel>
    where TModel : class
{
    private readonly Dictionary<EndpointSignature, IFluxRestSetEndpointOptions<TModel>> _values = [];

    public IFluxRestSetOptions<TModel> SetOptions { get; } = setOptions;

    private readonly DefaultFluxRestSetEndpointOptionsCollection<TModel, TKey> _defaultOptions = new();

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

    private IFluxRestSetEndpointOptions<TModel, TInputParameters> ResolveOptions<TInputParameters>(EndpointType endpointType, string? endpointName = null)
        where TInputParameters : IRequestParameters?
    {
        var inputParametersType = typeof(TInputParameters);
        var signature = new EndpointSignature(endpointType, inputParametersType);

        if (_values.TryGetValue(signature, out var endpointOptions))
            return (IFluxRestSetEndpointOptions<TModel, TInputParameters>)endpointOptions;

        if (endpointName is not null)
            throw new Exception($"{endpointType.GetFriendlyEndpointTypeName()} with name: '{endpointName}' not found.");

        return _defaultOptions.GetDefaultInstance<TInputParameters>(SetOptions, endpointType);
    }
    
    // TODO: When implementing 'Named endpoints' functionality: add endpoint name,
    // figure out resolve logic when enpoint name provided/not provided
    private record EndpointSignature(EndpointType EndpointType, Type InputParametersType);
}

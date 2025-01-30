
namespace BitzArt.Flux.REST;

/// <summary>
/// <inheritdoc cref="IFluxRestSetEndpointsCollection{TModel}"/>/>
/// </summary>
internal class FluxRestSetEndpointCollection<TModel, TKey> : IFluxRestSetEndpointsCollection<TModel>
    where TModel : class
{
    private readonly Dictionary<EndpointSignature, IFluxRestSetEndpointOptions<TModel>> _values = [];

    public void Add<TInputParameters>(IFluxRestSetEndpointOptions<TModel, TInputParameters> endpointOptions)
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

    private IFluxRestSetEndpointOptions<TModel, TInputParameters>? Get<TInputParameters>(EndpointType endpointType)
    {
        var inputParametersType = typeof(TInputParameters);
        var signature = new EndpointSignature(endpointType, inputParametersType);

        if (_values.TryGetValue(signature, out var endpointOptions))
            return (IFluxRestSetEndpointOptions<TModel, TInputParameters>)endpointOptions;

        return null;
    }

    private record EndpointSignature(EndpointType EndpointType, Type? InputParametersType);
}

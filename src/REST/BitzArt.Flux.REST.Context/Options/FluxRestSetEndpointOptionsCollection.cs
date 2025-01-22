namespace BitzArt.Flux.REST;

/// <summary>
/// <inheritdoc cref="IFluxRestSetEndpointOptionsCollection{TModel}"/>/>
/// </summary>
internal class FluxRestSetEndpointOptionsCollection<TModel, TKey> : IFluxRestSetEndpointOptionsCollection<TModel>
    where TModel : class
{
    private readonly Dictionary<EndpointSignature, IFluxRestSetEndpointOptions<TModel>> _values = [];

    public void Add<TOptions>(TOptions options)
        where TOptions : IFluxRestSetEndpointOptions<TModel>
    {
        switch (options)
        {
            case IFluxRestSetIdEndpointOptions<TModel> idEndpointOptions:
                Add(idEndpointOptions);
                break;
            case IFluxRestSetPageEndpointOptions<TModel> pageEndpointOptions:
                Add(pageEndpointOptions);
                break;
            case IFluxRestSetEndpointOptions<TModel> endpointOptions:
                Add(endpointOptions);
                break;
            default:
                throw new ArgumentException($"Unsupported options type: {options.GetType()}");
        }
    }

    private void Add(IFluxRestSetEndpointOptions<TModel> endpointOptions)
        => Add(EndpointType.Default, endpointOptions, typeof(IFluxRestSetEndpointOptions<,>));

    private void Add(IFluxRestSetIdEndpointOptions<TModel> idEndpointOptions)
        => Add(EndpointType.Id, idEndpointOptions, typeof(IFluxRestSetIdEndpointOptions<,>));

    private void Add(IFluxRestSetPageEndpointOptions<TModel> pageEnpointOptions)
        => Add(EndpointType.Page, pageEnpointOptions, typeof(IFluxRestSetPageEndpointOptions<,>));

    private void Add(EndpointType endpointType, IFluxRestSetEndpointOptions<TModel> endpointOptions, Type parameterizedOptionsType)
    {
        var endpointOptionsType = endpointOptions.GetType();
        var inputParametersType = endpointOptionsType.GetType().GetInterfaces()
            .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == parameterizedOptionsType)
            .Select(x => x.GetGenericArguments()[1])
            .FirstOrDefault();

        var signature = new EndpointSignature(endpointType, inputParametersType);
        if (!_values.TryAdd(signature, endpointOptions))
            throw new InvalidOperationException($"Options for endpoint type '{endpointType}' and input parameters type '{inputParametersType}' already added.");
    }

    public IFluxRestSetEndpointOptions<TModel, TInputParameters> Get<TInputParameters>(EndpointType endpointType)
        => (IFluxRestSetEndpointOptions<TModel, TInputParameters>)Get(endpointType, typeof(TInputParameters));

    public IFluxRestSetEndpointOptions<TModel> Get(EndpointType endpointType, Type? inputParametersType = null)
    {
        var signature = new EndpointSignature(endpointType, inputParametersType);
        if (_values.TryGetValue(signature, out var options))
            return options;

        throw new InvalidOperationException($"Options for endpoint type '{endpointType}' and input parameters type '{inputParametersType}' not found.");
    }

    private record EndpointSignature(EndpointType EndpointType, Type? InputParametersType);
}

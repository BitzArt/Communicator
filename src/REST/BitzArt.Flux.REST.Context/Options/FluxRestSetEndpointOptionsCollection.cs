

namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptionsCollection<TModel, TKey> : IFluxRestSetEndpointOptionsCollection<TModel>
    where TModel : class
{
    private readonly Dictionary<EnpointSignature, IFluxRestSetEndpointOptions<TModel>> _values = [];

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

    private void Add(IFluxRestSetEndpointOptions<TModel> idOptions)
        => Add(EndpointType.Default, idOptions, typeof(IFluxRestSetEndpointOptions<,>));

    private void Add(IFluxRestSetIdEndpointOptions<TModel> idOptions)
        => Add(EndpointType.Id, idOptions, typeof(IFluxRestSetIdEndpointOptions<,>));

    private void Add(IFluxRestSetPageEndpointOptions<TModel> idOptions)
        => Add(EndpointType.Page, idOptions, typeof(IFluxRestSetPageEndpointOptions<,>));

    private void Add(EndpointType endpointType, IFluxRestSetEndpointOptions<TModel> options, Type parameterizedOptionsType)
    {
        var type = options.GetType();
        var inputParametersType = type.GetInterfaces()
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == parameterizedOptionsType)
            .Select(i => i.GetGenericArguments()[1])
            .FirstOrDefault();

        _values.Add(new(endpointType, inputParametersType), options);
    }

    public IFluxRestSetEndpointOptions<TModel, TInputParameters> Get<TInputParameters>(EndpointType endpointType)
        => (IFluxRestSetEndpointOptions<TModel, TInputParameters>)Get(endpointType, typeof(TInputParameters));

    public IFluxRestSetEndpointOptions<TModel> Get(EndpointType endpointType, Type? inputParametersType = null)
    {
        var signature = new EnpointSignature(endpointType, inputParametersType);
        if (_values.TryGetValue(signature, out var options))
            return options;

        throw new InvalidOperationException($"Options for endpoint type {endpointType} and input parameters type {inputParametersType} not found.");
    }

    private record EnpointSignature(EndpointType EndpointType, Type? InputParametersType);
}

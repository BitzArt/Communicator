using System.Diagnostics;

namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(
    IFluxRestSetOptions<TModel> setOptions,
    string? path = null,
    Func<TInputParameters?, IRestRequestParameters>? transformParametersFunc = null) : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    /// <inheritdoc/>
    public Func<TInputParameters, IRestRequestParameters>? TransformParametersFunc { get; set; } = transformParametersFunc;

    public IFluxRestSetOptions<TModel> SetOptions { get; set; } = setOptions;

    /// <inheritdoc/>
    public string? Path { get; set; } = path;

    private static readonly DefaultFluxRestSetEndpointOptionsCollection<FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>, TModel> _defaultOptions
        = new((setOptions) => new FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(setOptions));

    public static FluxRestSetEndpointOptions<TModel, TKey, TInputParameters> GetDefaultInstance(IFluxRestSetOptions<TModel> setOptions, string? name = null)
        => _defaultOptions.GetDefaultInstance(setOptions, name);

    public HttpRequestMessage PrepareRequest(IRequestPreparationParameters parameters)
    {
        var path = BuildRequestPath(parameters);
        var requestMessage = parameters.InitialCreateRequestMessageFunc(path);

        return requestMessage;
    }

    private protected virtual string BuildRequestPath(IRequestPreparationParameters parameters)
    {
        var path = GetInitialPath();
        var outputParameters = ProcessParameters(parameters);
        var parse = RequestParameterParsingUtility.ParseRequestUrl(path, outputParameters);

        return parse.Result;
    }

    private protected virtual string GetInitialPath()
    {
        return CombinePath(SetOptions.ServiceOptions.BaseUrl, SetOptions.Path?.Trim('/'), Path?.Trim('/'));
    }

    private protected IRestRequestParameters? ProcessParameters(IRequestPreparationParameters parameters)
    {
        if (TransformParametersFunc is not null)
        {
            if (parameters.RequestParameters is not TInputParameters inputParameters)
                throw new UnreachableException();

            return TransformParametersFunc.Invoke(inputParameters); 
        }

        if (parameters.RequestParameters is null)
            return null;

        if (parameters.RequestParameters is not IRestRequestParameters restRequestParameters)
            throw new ArgumentException(); // TODO: add exception message

        return restRequestParameters;
    }

    protected static string CombinePath(params string?[] segments)
        => string.Join('/', segments.Where(x => !string.IsNullOrEmpty(x)));
}

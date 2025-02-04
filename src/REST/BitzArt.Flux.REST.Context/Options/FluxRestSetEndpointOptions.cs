using System.Diagnostics;

namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(
    string? path = null, 
    Func<TInputParameters?, IRestRequestParameters>? transformParametersFunc = null) 
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    /// <inheritdoc/>
    public Func<TInputParameters, IRestRequestParameters>? TransformParametersFunc { get; set; } = transformParametersFunc;

    /// <inheritdoc/>
    public string? Path { get; set; } = path;

    public static FluxRestSetEndpointOptions<TModel, TKey, TInputParameters> Instance => instance ?? new();

    private static readonly FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>? instance;

    public HttpRequestMessage PrepareRequest(IRequestPreparationParameters parameters)
    {
        if (parameters.RequestParameters is not TInputParameters inputParameters)
        {
            throw new UnreachableException();
        }

        var restRequestParameters = ProcessParameters(parameters, inputParameters);
        var path = GetPath(parameters);
        var parse = RequestParameterParsingUtility.ParseRequestUrl(path, restRequestParameters);

        var requestMessage = parameters.InitialCreateRequestMessageFunc!(parse.Result);
        return requestMessage;
    }

    private protected virtual string GetPath(IRequestPreparationParameters parameters)
    {
        throw new NotImplementedException();
    }

    private IRestRequestParameters ProcessParameters(IRequestPreparationParameters parameters, TInputParameters inputParameters)
    {
        if (TransformParametersFunc is not null)
        {
            return TransformParametersFunc.Invoke(inputParameters);
        }

        if (parameters.RequestParameters is not IRestRequestParameters restRequestParameters)
        {
            throw new ArgumentException();
        }

        return restRequestParameters;
    }
}

namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(
    string? path = null, 
    Func<TInputParameters, IRestRequestParameters>? transformParametersFunc = null) 
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    /// <inheritdoc/>
    public Func<TInputParameters, IRestRequestParameters>? TransformParametersFunc { get; set; } = transformParametersFunc;

    /// <inheritdoc/>
    public string? Path { get; set; } = path;
}

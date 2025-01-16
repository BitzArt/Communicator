namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(
    string? path, 
    Func<TInputParameters, IRestRequestParameters>? transformRequestParametersFunc) 
    : FluxRestSetEndpointOptions<TModel, TKey>(path), IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    public Func<TInputParameters, IRestRequestParameters>? TransformRequestParametersFunc { get; set; } = transformRequestParametersFunc;
}

internal class FluxRestSetEndpointOptions<TModel, TKey>(string? path) : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <inheritdoc/>
    public string? Path { get; set; } = path;
}

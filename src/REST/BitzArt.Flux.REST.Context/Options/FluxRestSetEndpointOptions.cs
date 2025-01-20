namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(
    string? path = null, 
    Func<TInputParameters, IRestRequestParameters>? transformParametersFunc = null) 
    : FluxRestSetEndpointOptions<TModel, TKey>(path), IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    /// <inheritdoc/>
    public Func<TInputParameters, IRestRequestParameters>? TransformParametersFunc { get; set; } = transformParametersFunc;
}

internal class FluxRestSetEndpointOptions<TModel, TKey>(string? path = null) : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <inheritdoc/>
    public string? Path { get; set; } = path;
}

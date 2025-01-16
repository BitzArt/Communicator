namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(
    string? path, 
    HttpMethod? method, 
    Func<TInputParameters, IRestRequestParameters>? transformRequestParametersFunc) 
    : FluxRestSetEndpointOptions<TModel, TKey>(path, method), IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    public Func<TInputParameters, IRestRequestParameters>? TransformRequestParametersFunc { get; set; } = transformRequestParametersFunc;
}

internal class FluxRestSetEndpointOptions<TModel, TKey>(string? path, HttpMethod? method) : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <inheritdoc/>
    public string? Path { get; set; } = path;

    /// <inheritdoc/>
    public HttpMethod? Method { get; set; } = method;
}

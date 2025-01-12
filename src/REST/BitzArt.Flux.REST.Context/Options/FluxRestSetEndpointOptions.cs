namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <inheritdoc/>
    public string? Path { get; set; }

    /// <inheritdoc/>
    public HttpMethod? Method { get; set; }

    public Type? RequestParametersType { get; set; }

    public Func<IFluxRequestParameters, IFluxRequestParameters>? GetParametersFunc { get; set; }
}
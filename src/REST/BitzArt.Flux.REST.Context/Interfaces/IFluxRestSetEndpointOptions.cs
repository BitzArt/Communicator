namespace BitzArt.Flux.REST;

internal interface IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    public Func<TInputParameters, IRestRequestParameters>? TransformRequestParametersFunc { get; internal set; }
}

internal interface IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <summary>
    /// A path to the endpoint.
    /// Can be null if other approach to building the endpoint path is used.
    /// </summary>
    public string? Path { get; internal set; }
}

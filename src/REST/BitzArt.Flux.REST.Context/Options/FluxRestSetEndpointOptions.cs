namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <inheritdoc/>
    public string? Path { get; set; }

    /// <inheritdoc/>
    public HttpMethod? Method { get; set; }

    public Type? ParametersType { get; set; }

    internal Func<IRequestParameters, IRestRequestParameters>? GetRequestParametersFunc { get; set; }

    // TODO: Review the implementation
    Func<IRequestParameters, IRestRequestParameters>? IFluxRestSetEndpointOptions<TModel>.GetRequestParametersFunc
    {
        get => GetRequestParametersFunc is null ? null : parameters =>
        {
            var parametersType = parameters.GetType();
            if (ParametersType != parametersType)
                throw new InvalidOperationException($"Request parameters type mismatch. Expected '{ParametersType}', but got '{parametersType}'.");

            return GetRequestParametersFunc.Invoke(parameters);
        };

        set
        {
            if (value is null)
            {
                GetRequestParametersFunc = null;
                return;
            }

            GetRequestParametersFunc = value.Invoke;
        }
    }
}
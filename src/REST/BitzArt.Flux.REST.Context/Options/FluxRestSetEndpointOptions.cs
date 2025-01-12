namespace BitzArt.Flux.REST;

internal class FluxRestSetEndpointOptions<TModel, TKey> : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    /// <inheritdoc/>
    public string? Path { get; set; }

    /// <inheritdoc/>
    public HttpMethod? Method { get; set; }

    public Type? InputParametersType { get; set; }

    internal Func<IFluxRequestParameters, IFluxRequestParameters>? GetRequestParametersFunc { get; set; }

    // TODO: Review the implementation
    Func<IFluxRequestParameters, IFluxRequestParameters>? IFluxRestSetEndpointOptions<TModel>.GetRequestParametersFunc
    {
        get => GetRequestParametersFunc is null ? null : parameters =>
        {
            var requestParametersType = parameters.GetType();
            if (InputParametersType != requestParametersType)
                throw new InvalidOperationException($"Request parameters type mismatch. Expected '{InputParametersType}', but got '{requestParametersType}'.");

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
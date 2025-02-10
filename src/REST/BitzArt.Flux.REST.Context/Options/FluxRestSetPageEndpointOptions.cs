namespace BitzArt.Flux.REST;

internal class FluxRestSetPageEndpointOptions<TModel, TKey, TInputParameters>(
    IFluxRestSetOptions<TModel> setOptions,
    string? path = null, 
    Func<TInputParameters?, IRestRequestParameters>? transformParameters = null)
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(setOptions, path, transformParameters), IFluxRestSetPageEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    private static readonly DefaultFluxRestSetEndpointOptionsCollection<FluxRestSetPageEndpointOptions<TModel, TKey, TInputParameters>, TModel> _defaultOptions
        = new((setOptions) => new FluxRestSetPageEndpointOptions<TModel, TKey, TInputParameters>(setOptions));

    public new static FluxRestSetPageEndpointOptions<TModel, TKey, TInputParameters> GetDefaultInstance(IFluxRestSetOptions<TModel> setOptions, string? name = null)
        => _defaultOptions.GetDefaultInstance(setOptions, name);

    private protected override string BuildRequestPath(IRequestPreparationParameters parameters)
    {
        return "http://localhost/set?offset={offset}&limit={limit}";
    }
}

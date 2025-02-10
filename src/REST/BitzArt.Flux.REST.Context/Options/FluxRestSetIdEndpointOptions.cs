namespace BitzArt.Flux.REST;

internal class FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>, IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    public Func<TKey?, string>? GetPathFunc { get; set; }

    public FluxRestSetIdEndpointOptions(
        IFluxRestSetOptions<TModel> setOptions,
        string? path = null,
        Func<TKey?, string>? getPath = null,
        Func<TInputParameters?, IRestRequestParameters>? transformParameters = null)
        : base(setOptions, path, transformParameters)
    {
        if (getPath is not null)
            GetPathFunc = (id) => getPath(id);
    }

    // TODO: Refactor this method. Handle all cases
    private protected override string BuildRequestPath(IRequestPreparationParameters parameters)
    {
        var id = parameters.Id;

        if (GetPathFunc is not null)
            return GetPathFunc((TKey?)id);

        var result = CombinePath(
            SetOptions.ServiceOptions.BaseUrl?.Trim('/'), 
            SetOptions.Path?.Trim('/'), 
            Path?.Trim('/'), 
            id?.ToString());

        return result;
    }
}

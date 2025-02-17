namespace BitzArt.Flux.REST;

internal class FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>, IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    public Func<TKey, string>? GetPathFunc { get; set; }

    public FluxRestSetIdEndpointOptions(
        IFluxRestSetOptions<TModel> setOptions,
        string? path = null,
        Func<TKey, string>? getPath = null,
        Func<TInputParameters?, IRestRequestParameters>? transformParameters = null)
        : base(setOptions, path, transformParameters)
    {
        if (getPath is not null)
            GetPathFunc = (id) => getPath(id);
    }

    private protected override string BuildRequestPath(IRequestPreparationParameters parameters)
    {
        var id = parameters.Id;
        var path = Path;

        if (id is null)
        {
            if (GetPathFunc is not null)
                throw new InvalidOperationException();

            return CombinePath(SetOptions.ServiceOptions.BaseUrl, SetOptions.Path, path);
        }

        if (id is not TKey idCasted)
            throw new ArgumentException($"The provided id is not of type '{typeof(TKey)}'.");

        if (GetPathFunc is not null)
        {
            path = GetPathFunc(idCasted);
            return CombinePath(SetOptions.ServiceOptions.BaseUrl, SetOptions.Path, path);
        }

        return CombinePath(SetOptions.ServiceOptions.BaseUrl, SetOptions.Path, path, idCasted.ToString());
    }
}

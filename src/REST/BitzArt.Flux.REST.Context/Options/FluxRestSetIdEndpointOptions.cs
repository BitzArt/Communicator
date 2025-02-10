namespace BitzArt.Flux.REST;

internal class FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>, IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    public Func<TKey?, string>? GetPathFunc {  get; set; }

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

    private static readonly DefaultFluxRestSetEndpointOptionsCollection<FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>, TModel> _defaultOptions
        = new((setOptions) => new FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>(setOptions));

    public new static FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters> GetDefaultInstance(IFluxRestSetOptions<TModel> setOptions, string? name = null)
        => _defaultOptions.GetDefaultInstance(setOptions, name);

    private protected override string BuildRequestPath(IRequestPreparationParameters parameters)
    {
        throw new NotImplementedException();
        //if (GetPathFunc is not null)
        //{
        //    return GetPathFunc(id);
        //}

        //if (parameters.Id is null)
        //    throw new Exception("");

        //return Path is not null
        //    ? System.IO.Path.Combine(Path, id.ToString()!)
        //    : id.ToString()!;
    }
}

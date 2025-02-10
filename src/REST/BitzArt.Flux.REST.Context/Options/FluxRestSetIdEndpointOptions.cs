namespace BitzArt.Flux.REST;

internal class FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>, IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    public Func<TKey?, string>? GetPathFunc;

    public FluxRestSetIdEndpointOptions(
        IFluxRestSetOptions<TModel> setOptions,
        string? path = null,
        Func<TKey?, string>? getPath = null,
        Func<TInputParameters?, IRestRequestParameters>? transformParameters = null)
        : base(setOptions, path, transformParameters)
    {
        if (getPath is not null)
            GetPathFunc = (id) => getPath(id!);
    }

    private static readonly DefaultFluxRestSetEndpointOptionsCollection<FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>, TModel> _defaultOptions
        = new((setOptions) => new FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>(setOptions));

    public new static FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters> GetDefaultInstance(IFluxRestSetOptions<TModel> setOptions, string? name = null)
        => _defaultOptions.GetDefaultInstance(setOptions, name);

    private protected override string BuildRequestPath(IRequestPreparationParameters parameters)
    {
        var idValid = ValidateId(parameters, out var id);

        if (GetPathFunc is not null)
        {
            return GetPathFunc(id);
        }

        if (parameters.Id is null)
            throw new Exception("");

        return Path is not null
            ? System.IO.Path.Combine(Path, id.ToString()!)
            : id.ToString()!;
    }

    private TKey? ValidateId(IRequestPreparationParameters parameters)
    {
        return null;

        if (parameters.Id is null)
            return true;

        if (parameters.Id is not TKey idCasted)
            return false;

        id = idCasted;
        return true;
    }
}

file class GetPathByIdFunc<TModel, TKey>() : IGetPathByIdFunc
    where TModel : class
{
    public Func<object?, string>? Value
    {
        get => _value is null ? null : (id) =>
        {
            if (id is not TKey idTyped)
                throw new InvalidOperationException($"Id type mismatch. Expected {typeof(TKey)}, but got {id?.GetType()}.");

            return _value.Invoke(idTyped);
        };

        set
        {
            if (value is null)
            {
                _value = null;
                return;
            }

            _value = (id) => value.Invoke(id);
        }
    }

    private Func<TKey?, string>? _value { get; set; }
}

namespace BitzArt.Flux.REST;

internal class FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>, IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    public IGetPathByIdFunc GetPathFunc { get; set; } = new GetPathByIdFunc<TModel, TKey>();

    public static new FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters> Instance => instance ?? new();

    private static readonly FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>? instance;

    public FluxRestSetIdEndpointOptions(
        string? path = null,
        Func<TKey, string>? getPath = null,
        Func<TInputParameters?, IRestRequestParameters>? transformParameters = null)
        : base(path, transformParameters)
    {
        if (getPath is not null)
            GetPathFunc.Value = getPath as Func<object?, string>;
    }

    private protected override string GetPath(IRequestPreparationParameters parameters)
    {
        var id = parameters.Id!;

        if (GetPathFunc.Value is not null)
            return GetPathFunc.Value(id);

        return Path is not null 
            ? System.IO.Path.Combine(Path, id.ToString()!) 
            : id.ToString()!;
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

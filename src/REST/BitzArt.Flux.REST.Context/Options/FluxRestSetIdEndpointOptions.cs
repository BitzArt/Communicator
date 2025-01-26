namespace BitzArt.Flux.REST;

internal class FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters>
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>, IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    where TModel : class
{
    public IGetPathByIdFunc GetPathFunc { get; set; } = new GetPathByIdFunc<TModel, TKey>();

    public FluxRestSetIdEndpointOptions(
        string? path = null,
        Func<TKey, string>? getPath = null,
        Func<TInputParameters, IRestRequestParameters>? transformParameters = null)
        : base(path, transformParameters)
    {
        if (getPath is not null)
            GetPathFunc.Value = getPath as Func<object?, string>;
    }
}

file class GetPathByIdFunc<TModel, TKey>() : IGetPathByIdFunc
    where TModel : class
{
    public Func<object?, string>? Value
    {
        get => _value is null ? null : (key) =>
        {
            if (key is not TKey keyTyped)
                throw new InvalidOperationException($"Key type mismatch. Expected {typeof(TKey)}, but got {key?.GetType()}.");

            return _value.Invoke(keyTyped);
        };

        set
        {
            if (value is null)
            {
                _value = null;
                return;
            }

            _value = (key) => value.Invoke(key);
        }
    }

    private Func<TKey?, string>? _value { get; set; }
}

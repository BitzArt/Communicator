namespace BitzArt.Flux;

/// <summary>
/// Flux Set Context base class.
/// </summary>
public abstract partial class FluxSetContext<TModel, TKey> : IFluxSetContext<TModel, TKey>
    where TModel : class
{
    private static TResult Cast<TResult>(object? value)
    {
        if (value is not TResult casted)
            throw new InvalidOperationException($"Invalid key type. Expected '{typeof(TResult).Name}' but got '{value?.GetType().Name ?? "null"}'.");

        return casted;
    }
}

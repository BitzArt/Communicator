namespace BitzArt.Flux;

/// <summary>
/// Base class for set context implementations.
/// </summary>
public abstract partial class FluxSetContext<TModel, TKey> : IFluxSetContext<TModel, TKey>
    where TModel : class
{
    private static TKey CastId(object value)
    {
        if (value is not TKey valueCasted)
            throw new InvalidOperationException($"Invalid key type. Expected '{typeof(TKey).Name}' but got '{value.GetType().Name}'.");

        return valueCasted;
    }
}

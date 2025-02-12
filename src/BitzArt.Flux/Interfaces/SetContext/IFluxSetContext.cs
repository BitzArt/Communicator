namespace BitzArt.Flux;

/// <summary>
/// Flux context for a preconfigured data Set.<br/>
/// See <see href="https://bitzart.github.io/Flux/03.use.html">Use Flux</see>
/// for more information on how to use it.
/// </summary>
/// <typeparam name="TModel">
/// The model type of the set.
/// </typeparam>
public partial interface IFluxSetContext<TModel>
    where TModel : class
{
}

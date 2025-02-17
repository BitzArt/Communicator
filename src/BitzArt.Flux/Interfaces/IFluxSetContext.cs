using BitzArt.Flux.Sets;

namespace BitzArt.Flux;

/// <inheritdoc cref="IFluxSetContext{TModel, TKey}"/>
public interface IFluxSetContext<TModel> :
    IFluxSetAddOperations<TModel>,
    IFluxSetGetAllOperations<TModel>,
    IFluxSetGetOperations<TModel>,
    IFluxSetGetPageOperations<TModel>,
    IFluxSetUpdateOperations<TModel>
    where TModel : class
{
}

/// <summary>
/// Flux context for a preconfigured data Set.<br/>
/// See <see href="https://bitzart.github.io/Flux/03.use.html"/>
/// for more information on how you can use Flux in your applications.
/// </summary>
/// <typeparam name="TModel">Model type of the set.</typeparam>
/// <typeparam name="TKey">Key type of the set.</typeparam>
public interface IFluxSetContext<TModel, TKey> :
    IFluxSetContext<TModel>,
    IFluxSetGetOperations<TModel, TKey>,
    IFluxSetUpdateOperations<TModel, TKey>
    where TModel : class
{
}

using BitzArt.Flux.REST;

namespace BitzArt.Flux;

public interface IFluxRestSetIdEndpointBuilder<TModel, TKey, TInputParameters> : IFluxRestSetBuilder<TModel, TKey>
    where TModel : class
{
    internal FluxRestSetIdEndpointOptions<TModel, TKey, TInputParameters> EndpointOptions { get; }
}

/// <summary>
/// Flux REST set endpoint builder.
/// </summary>
/// /// <typeparam name="TModel">
/// The model type of the set.
/// </typeparam>
/// <typeparam name="TKey">
/// The key type of the set.
/// </typeparam>
public interface IFluxRestSetIdEndpointBuilder<TModel, TKey> : IFluxRestSetBuilder<TModel, TKey>
    where TModel : class
{
    internal FluxRestSetIdEndpointOptions<TModel, TKey> EndpointOptions { get; }
}

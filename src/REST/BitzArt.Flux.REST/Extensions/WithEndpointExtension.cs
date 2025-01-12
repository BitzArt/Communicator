using BitzArt.Flux.REST;

namespace BitzArt.Flux;

/// <summary>
/// Extension methods for configuring default set endpoint in <see cref="IFluxRestSetBuilder{TModel, TKey}"/>
/// </summary>
public static class WithEndpointExtension
{
    /// <summary>
    /// Configures the default endpoint for the <see cref="IFluxRestSetBuilder{TModel, TKey}"/>
    /// </summary>
    /// <returns>
    /// The <see cref="IFluxRestSetBuilder{TModel, TKey}"/> with the endpoint configured
    /// </returns>
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TModel, TKey>(this IFluxRestSetBuilder<TModel, TKey> builder, string endpoint)
        where TModel : class
    {
        builder.SetOptions.EndpointOptions.Path = endpoint;

        return new FluxRestSetEndpointBuilder<TModel, TKey>(builder, (FluxRestSetEndpointOptions<TModel, TKey>)builder.SetOptions.EndpointOptions);
    }
}

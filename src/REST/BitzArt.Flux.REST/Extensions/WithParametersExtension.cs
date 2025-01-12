namespace BitzArt.Flux;

public static class WithParametersExtension
{
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey>(
        this IFluxRestSetEndpointBuilder<TModel, TKey> builder,
        Func<FluxRequestParameters, IFluxRequestParameters> getParameters)
        where TModel : class
        => builder.WithParameters<TModel, TKey, FluxRequestParameters>(getParameters);

    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey, TRequestParameters>(
        this IFluxRestSetEndpointBuilder<TModel, TKey> builder,
        Func<TRequestParameters, IFluxRequestParameters> getParameters)
        where TModel : class
        where TRequestParameters : IFluxRequestParameters
    {
        builder.EndpointOptions.RequestParametersType = typeof(TRequestParameters);
        builder.EndpointOptions.GetParametersFunc = (parameters) => getParameters((TRequestParameters)parameters);

        return builder;
    }

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey>(
        this IFluxRestSetIdEndpointBuilder<TModel, TKey> builder,
        Func<FluxRequestParameters, IFluxRequestParameters> getParameters)
        where TModel : class
        => builder.WithParameters<TModel, TKey, FluxRequestParameters>(getParameters);

    public static IFluxRestSetIdEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey, TRequestParameters>(
        this IFluxRestSetIdEndpointBuilder<TModel, TKey> builder,
        Func<TRequestParameters, IFluxRequestParameters> getParameters)
        where TModel : class
        where TRequestParameters : IFluxRequestParameters
    {
        builder.EndpointOptions.RequestParametersType = typeof(TRequestParameters);
        builder.EndpointOptions.GetParametersFunc = (parameters) => getParameters((TRequestParameters)parameters);

        return builder;
    }
}

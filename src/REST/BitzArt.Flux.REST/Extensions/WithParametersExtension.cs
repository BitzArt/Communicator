namespace BitzArt.Flux;

public static class WithParametersExtension
{
    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey>(
        this IFluxRestSetEndpointBuilder<TModel, TKey> builder,
        Func<FluxRestRequestParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        => builder.WithParameters<TModel, TKey, FluxRestRequestParameters, FluxRestRequestParameters>(getParameters);

    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey, TInputParameters>(
        this IFluxRestSetEndpointBuilder<TModel, TKey> builder,
        Func<TInputParameters, FluxRestRequestParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        => builder.WithParameters<TModel, TKey, TInputParameters, FluxRestRequestParameters>(getParameters);

    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey, TOutputParameters>(
        this IFluxRestSetEndpointBuilder<TModel, TKey> builder,
        Func<FluxRestRequestParameters, TOutputParameters> getParameters)
        where TModel : class
        where TOutputParameters : IFluxRestRequestParameters
        => builder.WithParameters<TModel, TKey, FluxRestRequestParameters, TOutputParameters>(getParameters);

    public static IFluxRestSetEndpointBuilder<TModel, TKey> WithParameters<TModel, TKey, TInputParameters, TOutputParameters>(
        this IFluxRestSetEndpointBuilder<TModel, TKey> builder,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TModel : class
        where TInputParameters : IFluxRequestParameters
        where TOutputParameters : IFluxRestRequestParameters
    {
        builder.EndpointOptions.InputParametersType = typeof(TInputParameters);
        builder.EndpointOptions.GetRequestParametersFunc = (parameters) => getParameters((TInputParameters)parameters);

        return builder;
    }
}

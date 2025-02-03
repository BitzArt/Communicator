namespace BitzArt.Flux.REST;

internal interface IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : class, IRequestParameters
{
    public IGetPathByIdFunc GetPathFunc { get; set; }

    public RequestUrlParameterParsingResult ParseParameters<TKey>(TKey id, TInputParameters? parameters);
}

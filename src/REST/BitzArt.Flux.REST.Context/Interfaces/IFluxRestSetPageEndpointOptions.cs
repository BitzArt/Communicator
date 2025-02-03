using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

internal interface IFluxRestSetPageEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : class, IRequestParameters
{
    public RequestUrlParameterParsingResult ParseParameters(PageRequest pageRequest, TInputParameters? parameters);
}

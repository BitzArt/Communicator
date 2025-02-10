using BitzArt.Pagination;
using System.Web;

namespace BitzArt.Flux.REST;

internal class FluxRestSetPageEndpointOptions<TModel, TKey, TInputParameters>(
    IFluxRestSetOptions<TModel> setOptions,
    string? path = null, 
    Func<TInputParameters?, IRestRequestParameters>? transformParameters = null)
    : FluxRestSetEndpointOptions<TModel, TKey, TInputParameters>(setOptions, path, transformParameters), IFluxRestSetPageEndpointOptions<TModel, TInputParameters>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
    private protected override string BuildRequestPath(IRequestPreparationParameters parameters)
    {
        if (parameters.PageRequest is null)
            throw new Exception(); // TODO: add message

        var path = GetInitialPath();
        path = ApplyPageParameters(path, parameters.PageRequest);

        var outputParameters = ProcessParameters(parameters);
        
        return RequestParameterParsingUtility.ParseRequestUrl(path, outputParameters);
    }

    private static string ApplyPageParameters(string path, PageRequest pageRequest)
    {
        var queryIndex = path.IndexOf('?');

        var query = queryIndex == -1 ?
            HttpUtility.ParseQueryString(string.Empty) :
            HttpUtility.ParseQueryString(path[queryIndex..]);

        query.Add("offset", pageRequest.Offset?.ToString());
        query.Add("limit", pageRequest.Limit?.ToString());

        if (queryIndex != -1) path = path[..queryIndex];
        path = path + "?" + query.ToString();

        return path;
    }
}

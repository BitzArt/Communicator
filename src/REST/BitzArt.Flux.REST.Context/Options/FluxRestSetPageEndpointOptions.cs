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
            throw new ArgumentNullException(); // TODO: add message

        var path = GetInitialPath();
        path = ApplyPaginationParameters(path, parameters.PageRequest);

        var outputParameters = HandleInputParameters(parameters);

        return RequestParameterParsingUtility.ParseRequestUrl(path, outputParameters);
    }

    private static string ApplyPaginationParameters(string path, PageRequest pageRequest)
    {
        var queryIndex = path.IndexOf('?');
        var basePath = queryIndex == -1 ? path : path[..queryIndex];

        var query = queryIndex == -1 ?
            HttpUtility.ParseQueryString(string.Empty) :
            HttpUtility.ParseQueryString(path[queryIndex..]);

        if (pageRequest.Offset.HasValue)
            query["offset"] = pageRequest.Offset.Value.ToString();

        if (pageRequest.Limit.HasValue)
            query["limit"] = pageRequest.Limit.Value.ToString();

        return query.Count > 0
            ? $"{basePath}?{query}"
            : basePath;
    }
}

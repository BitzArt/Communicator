using BitzArt.Pagination;
using Microsoft.Extensions.Logging;
using System.Web;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override async Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override async Task<PageResult<TModel>> GetPageAsync<TParameter>(PageRequest pageRequest, IRequestParameters<TParameter> parameters, CancellationToken cancellationToken = default)
    {
        var parsed = GetPageEndpointFullPath(pageRequest, parameters);
        _logger.LogInformation("GetPage {type}: {route}{parsingLog}", typeof(TModel).Name, parsed.Result, parsed.Log);

        var message = new HttpRequestMessage(HttpMethod.Get, parsed.Result);
        var result = await HandleRequestAsync<PageResult<TModel>>(message, cancellationToken);

        return result;
    }

    private RequestUrlParameterParsingResult GetPageEndpointFullPath(PageRequest pageRequest, IRequestParameters? parameters)
    {
        var path = GetPageEndpoint();
        var restParameters = TransformParameters(SetOptions.PageEndpointOptions, parameters);
        var parsed = GetFullPath(path, restParameters);
        path = parsed.Result;

        var queryIndex = path.IndexOf('?');

        var query = queryIndex == -1 ?
            HttpUtility.ParseQueryString(string.Empty) :
            HttpUtility.ParseQueryString(path[queryIndex..]);

        query.Add("offset", pageRequest.Offset?.ToString());
        query.Add("limit", pageRequest.Limit?.ToString());

        if (queryIndex != -1) path = path[..queryIndex];
        path = path + "?" + query.ToString();

        parsed.Result = path;

        return parsed;
    }

    private string GetPageEndpoint()
    {
        if (SetOptions.PageEndpointOptions.Path is not null)
            return SetOptions.PageEndpointOptions.Path;

        return GetEndpoint();
    }
}

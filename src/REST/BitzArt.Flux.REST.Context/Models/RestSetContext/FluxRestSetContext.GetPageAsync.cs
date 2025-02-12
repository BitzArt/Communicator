using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override async Task<PageResult<TModel>> GetPageAsync(PageRequest pageRequest, CancellationToken cancellationToken = default)
    {
        var preparationParameters = new RequestPreparationParameters<RestRequestParameters, TKey>(EndpointType.Page, pageRequest, null, (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters>(preparationParameters);

        return await HandleRequestAsync<PageResult<TModel>>(requestMessage, cancellationToken);
    }

    public override async Task<PageResult<TModel>> GetPageAsync<TInputParameters>(PageRequest pageRequest, TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        var preparationParameters = new RequestPreparationParameters<TInputParameters, TKey>(EndpointType.Page, pageRequest, parameters, (path) =>
             new HttpRequestMessage(HttpMethod.Get, path));

        var requestMessage = SetOptions.EndpointCollection.Resolve<TInputParameters>(preparationParameters);

        return await HandleRequestAsync<PageResult<TModel>>(requestMessage, cancellationToken);
    }
}

using BitzArt.Pagination;

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
        throw new NotImplementedException();
    }

    private string GetPageEndpoint()
    {
        if (SetOptions.PageEndpointOptions.Path is not null)
            return SetOptions.PageEndpointOptions.Path;

        return GetEndpoint();
    }
}

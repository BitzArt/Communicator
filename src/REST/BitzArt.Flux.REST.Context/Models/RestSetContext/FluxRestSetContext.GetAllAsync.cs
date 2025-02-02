using BitzArt.Pagination;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey>
{
    public override async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var requestMessage = SetOptions.EndpointsCollection.Resolve(EndpointType.Default, (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        return await HandleRequestAsync<IEnumerable<TModel>>(requestMessage, cancellationToken);
    }

    public override async Task<IEnumerable<TModel>> GetAllAsync<TInputParameters>(TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        //var requestMessage = SetOptions.EndpointsCollection.Resolve(EndpointType.Default, parameters, (path) => 
        //    new HttpRequestMessage(HttpMethod.Get, path));

        TKey id = default;

        var pageRequest = new PageRequest(1, 10);

        var requestMessage = SetOptions.EndpointsCollection.Resolve<TInputParameters, TKey>(EndpointType.Default, parameters, default, pageRequest, (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        return await HandleRequestAsync<IEnumerable<TModel>>(requestMessage, cancellationToken);
    }
}

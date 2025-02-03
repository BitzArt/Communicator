namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey>
{
    public override async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters, TKey>(EndpointType.Default, createRequestMessage: (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        return await HandleRequestAsync<IEnumerable<TModel>>(requestMessage, cancellationToken);
    }

    public override async Task<IEnumerable<TModel>> GetAllAsync<TInputParameters>(TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        var requestMessage = SetOptions.EndpointCollection.Resolve<TInputParameters, TKey>(EndpointType.Default, parameters, createRequestMessage: (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        return await HandleRequestAsync<IEnumerable<TModel>>(requestMessage, cancellationToken);
    }
}

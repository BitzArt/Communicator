namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey>
{
    public override async Task<TModel> GetAsync(TKey? id, CancellationToken cancellationToken = default)
    {
        var preparationParameters = new RequestPreparationParameters<RestRequestParameters, TKey>(EndpointType.Id, id, null, (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters>(preparationParameters);

        return await HandleRequestAsync<TModel>(requestMessage, cancellationToken);
    }

    public override async Task<TModel> GetAsync<TInputParameters>(TKey? id, TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        var preparationParameters = new RequestPreparationParameters<TInputParameters, TKey>(EndpointType.Id, id, parameters, (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        var requestMessage = SetOptions.EndpointCollection.Resolve<TInputParameters>(preparationParameters);

        return await HandleRequestAsync<TModel>(requestMessage, cancellationToken);
    }
}

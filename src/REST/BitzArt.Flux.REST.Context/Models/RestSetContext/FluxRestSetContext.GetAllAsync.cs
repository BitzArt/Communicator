namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey>
{
    public override async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var preparationParameters = new RequestPreparationParameters<RestRequestParameters, TKey>(EndpointType.Default, (path) => 
            new HttpRequestMessage(HttpMethod.Get, path));

        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters>(preparationParameters);

        return await HandleRequestAsync<IEnumerable<TModel>>(requestMessage, cancellationToken);
    }

    public override async Task<IEnumerable<TModel>> GetAllAsync<TInputParameters>(TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        var preparationParameters = new RequestPreparationParameters<TInputParameters, TKey>(EndpointType.Default, parameters, (path) =>
            new HttpRequestMessage(HttpMethod.Get, path));

        var requestMessage = SetOptions.EndpointCollection.Resolve<TInputParameters>(preparationParameters);

        return await HandleRequestAsync<IEnumerable<TModel>>(requestMessage, cancellationToken);
    }
}

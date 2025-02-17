using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override async Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default)
    {
        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);
        var method = partial ? HttpMethod.Patch : HttpMethod.Put;

        var preparationParameters = new RequestPreparationParameters<RestRequestParameters, TKey>(EndpointType.Id, (path) =>
            new HttpRequestMessage(method, path)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json)
            });

        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters>(preparationParameters);

        return await HandleRequestAsync<TResponse>(requestMessage, cancellationToken);
    }

    public override async Task<TResponse> UpdateAsync<TResponse>(TKey id, TModel model, bool partial = false, CancellationToken cancellationToken = default)
    {
        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);
        var method = partial ? HttpMethod.Patch : HttpMethod.Put;

        var preparationParameters = new RequestPreparationParameters<RestRequestParameters, TKey>(EndpointType.Id, id, (path) =>
            new HttpRequestMessage(method, path)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json)
            });

        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters>(preparationParameters);

        return await HandleRequestAsync<TResponse>(requestMessage, cancellationToken);
    }

    public override async Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
    {
        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);
        var method = partial ? HttpMethod.Patch : HttpMethod.Put;

        var preparationParameters = new RequestPreparationParameters<TInputParameters, TKey>(EndpointType.Id, parameters, (path) =>
            new HttpRequestMessage(method, path)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json)
            });

        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters>(preparationParameters);

        return await HandleRequestAsync<TResponse>(requestMessage, cancellationToken);
    }

    public override async Task<TResponse> UpdateAsync<TInputParameters, TResponse>(TKey id, TModel model, TInputParameters parameters, bool partial = false, CancellationToken cancellationToken = default)
    {
        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);
        var method = partial ? HttpMethod.Patch : HttpMethod.Put;

        var preparationParameters = new RequestPreparationParameters<TInputParameters, TKey>(EndpointType.Id, id, parameters, (path) =>
            new HttpRequestMessage(method, path)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json)
            });

        var requestMessage = SetOptions.EndpointCollection.Resolve<TInputParameters>(preparationParameters);

        return await HandleRequestAsync<TResponse>(requestMessage, cancellationToken);
    }
}

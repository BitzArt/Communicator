using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
{
    public override async Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default)
    {
        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);

        var preparationParameters = new RequestPreparationParameters<RestRequestParameters, TKey>(EndpointType.Id, null, (path) =>
            new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json)
            });

        var requestMessage = SetOptions.EndpointCollection.Resolve<RestRequestParameters>(preparationParameters);

        return await HandleRequestAsync<TResponse>(requestMessage, cancellationToken);
    }

    public override async Task<TResponse> AddAsync<TInputParameters, TResponse>(TModel model, TInputParameters parameters, CancellationToken cancellationToken = default)
    {
        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);

        var preparationParameters = new RequestPreparationParameters<TInputParameters, TKey>(EndpointType.Id, parameters, (path) =>
            new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json)
            });

        var requestMessage = SetOptions.EndpointCollection.Resolve<TInputParameters>(preparationParameters);

        return await HandleRequestAsync<TResponse>(requestMessage, cancellationToken);
    }
}

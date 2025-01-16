using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override async Task<TResponse> AddAsync<TResponse>(TModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override async Task<TResponse> AddAsync<TParameter, TResponse>(TModel model, IRequestParameters<TParameter> parameters, CancellationToken cancellationToken = default)
    {
        var parsed = GetEndpointFullPath(parameters);
        _logger.LogInformation("Add {type}: {route}", typeof(TModel).Name, parsed.Result);

        var jsonString = JsonSerializer.Serialize(model, ServiceOptions.SerializerOptions);
        var message = new HttpRequestMessage(HttpMethod.Post, parsed.Result)
        {
            Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
        };

        var result = await HandleRequestAsync<TResponse>(message, cancellationToken);

        return result;
    }
      
}

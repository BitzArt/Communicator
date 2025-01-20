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
        throw new NotImplementedException();
    }
      
}

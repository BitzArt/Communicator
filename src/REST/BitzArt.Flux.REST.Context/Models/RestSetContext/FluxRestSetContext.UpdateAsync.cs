using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace BitzArt.Flux.REST;

internal partial class FluxRestSetContext<TModel, TKey> : FluxSetContext<TModel, TKey>
    where TModel : class
{
    public override Task<TResponse> UpdateAsync<TResponse>(TModel model, bool partial = false, CancellationToken cancellationToken = default)
        => UpdateAsync<TResponse>(id: default, model, partial, cancellationToken);

    public override async Task<TResponse> UpdateAsync<TResponse>(TKey? id, TModel model, bool partial = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<TResponse> UpdateAsync<TParameter, TResponse>(TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default)
        => UpdateAsync<TParameter, TResponse>(id: default, model, parameters, partial, cancellationToken);

    public override async Task<TResponse> UpdateAsync<TParameter, TResponse>(TKey? id, TModel model, IRequestParameters<TParameter> parameters, bool partial = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

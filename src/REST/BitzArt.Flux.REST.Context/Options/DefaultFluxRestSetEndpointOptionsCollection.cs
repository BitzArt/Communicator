using System.Collections.Concurrent;

namespace BitzArt.Flux.REST;

internal class DefaultFluxRestSetEndpointOptionsCollection<TOptions, TModel>(Func<IFluxRestSetOptions<TModel>, TOptions> createNew)
    where TOptions : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
    public TOptions GetDefaultInstance(IFluxRestSetOptions<TModel> setOptions, string? name = null)
    {
        if (name is null)
            return _defaultUnnamedInstance ??= createNew.Invoke(setOptions);

        var found = _defaultNamedInstances.TryGetValue(name, out var instance);
        if (found) return instance!;

        var newDefaultInstance = createNew.Invoke(setOptions);
        _defaultNamedInstances[name] = newDefaultInstance;

        return newDefaultInstance;
    }

    private readonly ConcurrentDictionary<string, TOptions> _defaultNamedInstances = [];

    private TOptions? _defaultUnnamedInstance;
}

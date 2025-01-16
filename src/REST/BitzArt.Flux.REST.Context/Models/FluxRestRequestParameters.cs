using System.Collections;

namespace BitzArt.Flux;

public class FluxRestRequestParameters : IFluxRestRequestParameters, ICollection<KeyValuePair<string, object>>
{
    public int Count => Parameters.Count;

    public bool IsReadOnly => false;

    public Dictionary<string, object> Parameters { get; } = [];

    public FluxRestRequestParameters(params KeyValuePair<string, object>[] parameters) : this()
    {
        Parameters = parameters.ToDictionary(x => x.Key, x => x.Value);
    }

    public FluxRestRequestParameters()
    {
    }

    public KeyValuePair<string, object> TryGet(string key)
    {
        var exists = Parameters.TryGetValue(key, out var value);
        if (!exists) throw new Exception();

        return new KeyValuePair<string, object>(key, value!);
    }

    public void Add(string key, object value) => Add(new KeyValuePair<string, object>(key, value));

    public void Add(KeyValuePair<string, object> item) => Parameters.Add(item.Key, item.Value);

    public void Clear() => Parameters.Clear();

    public bool Contains(KeyValuePair<string, object> item) => Parameters.Contains(item);

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
        foreach (var item in Parameters)
            array[arrayIndex++] = item;
    }

    public bool Remove(KeyValuePair<string, object> item) => Parameters.Remove(item.Key);

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => Parameters.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Parameters).GetEnumerator();
}

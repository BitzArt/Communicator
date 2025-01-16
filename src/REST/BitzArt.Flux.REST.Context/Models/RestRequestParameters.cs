using System.Collections;

namespace BitzArt.Flux;

public class RestRequestParameters : IRestRequestParameters, ICollection<KeyValuePair<string, object>>
{
    public Dictionary<string, object> Parameters { get; } = [];

    public int Count => Parameters.Count;

    public bool IsReadOnly => false;

    public RestRequestParameters(params KeyValuePair<string, object>[] parameters) : this()
    {
        Parameters = parameters.ToDictionary(x => x.Key, x => x.Value);
    }

    public RestRequestParameters()
    {
    }

    public void Add(string key, object value) => Add(new KeyValuePair<string, object>(key, value));

    public void Add(KeyValuePair<string, object> item) => Parameters.Add(item.Key, item.Value);

    public void Clear() => Parameters.Clear();

    public bool Contains(KeyValuePair<string, object> item) => Parameters.Contains(item);

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => Parameters.ToArray().CopyTo(array, arrayIndex);

    public bool Remove(KeyValuePair<string, object> item) => Parameters.Remove(item.Key);

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => Parameters.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Parameters).GetEnumerator();
}

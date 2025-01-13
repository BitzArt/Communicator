using System.Collections;

namespace BitzArt.Flux;

public class FluxRestRequestParameters : FluxRequestParameters<KeyValuePair<string, object>>, IFluxRestRequestParameters, ICollection<KeyValuePair<string, object>>
{
    public int Count => Parameters.Count;

    public bool IsReadOnly => Parameters.IsReadOnly;

    public FluxRestRequestParameters(ICollection<KeyValuePair<string, object>> parameters) : this()
    {
        Parameters = parameters;
    }

    public FluxRestRequestParameters()
    {
    }

    public void Add(string key, object value) => Add(new KeyValuePair<string, object>(key, value));

    public void Add(KeyValuePair<string, object> item) => Parameters.Add(item);

    public void Clear() => Parameters.Clear();

    public bool Contains(KeyValuePair<string, object> item) => Parameters.Contains(item);

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => Parameters.CopyTo(array, arrayIndex);

    public bool Remove(KeyValuePair<string, object> item) => Parameters.Remove(item);

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => Parameters.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Parameters).GetEnumerator();
}

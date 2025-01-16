using System.Collections;

namespace BitzArt.Flux;

public class RestRequestParameters : IRestRequestParameters, ICollection<KeyValuePair<string, object>>
{
    public Dictionary<string, object> Parameters => GetDictionary.Invoke();

    private readonly Dictionary<string, object> _parameters = []; 

    ICollection<KeyValuePair<string, object>> IRequestParameters<KeyValuePair<string, object>>.Parameters => Parameters; 

    private ICollection<KeyValuePair<string, object>> _parameterCollection => Parameters;

    /// <inheritdoc/>
    public int Count => _parameterCollection.Count;

    /// <inheritdoc/>
    public bool IsReadOnly => _parameterCollection.IsReadOnly;

    public RestRequestParameters(params KeyValuePair<string, object>[] parameters) : this()
    {
        _parameters = new(parameters);
    }

    public RestRequestParameters()
    {
    }

    protected virtual Func<Dictionary<string, object>> GetDictionary => () => 
    { 
        if (GetParameters is null) return _parameters;

        var collection = GetParameters.Invoke();
        return new(collection);
    };

    protected virtual Func<ICollection<KeyValuePair<string, object>>>? GetParameters => null;

    /// <inheritdoc/>
    public void Add(KeyValuePair<string, object> item) => _parameterCollection.Add(item);

    /// <inheritdoc/>
    public void Clear() => _parameterCollection.Clear();

    /// <inheritdoc/>
    public bool Contains(KeyValuePair<string, object> item) => _parameterCollection.Contains(item);

    /// <inheritdoc/>
    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => _parameterCollection.CopyTo(array, arrayIndex);

    /// <inheritdoc/>
    public bool Remove(KeyValuePair<string, object> item) => _parameterCollection.Remove(item);

    /// <inheritdoc/>
    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _parameterCollection.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_parameterCollection).GetEnumerator();
}

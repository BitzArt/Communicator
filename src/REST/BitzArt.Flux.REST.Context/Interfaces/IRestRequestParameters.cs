namespace BitzArt.Flux;

public interface IRestRequestParameters
{
    public Dictionary<string, object> Parameters { get; }

    public KeyValuePair<string, object> TryGet(string key);
}

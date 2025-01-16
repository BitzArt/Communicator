namespace BitzArt.Flux;

public interface IFluxRestRequestParameters
{
    public Dictionary<string, object> Parameters { get; }

    public KeyValuePair<string, object> TryGet(string key);
}

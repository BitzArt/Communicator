namespace BitzArt.Flux;

public interface IRestRequestParameters : IRequestParameters
{
    public Dictionary<string, object> ValueMap { get; }
}

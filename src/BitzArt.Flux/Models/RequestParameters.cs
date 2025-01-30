using System.Collections;

namespace BitzArt.Flux;

public sealed class RequestParameters(params object?[] parameters) : RequestParameters<object?>(parameters)
{
}

public class RequestParameters<T> : IRequestParameters
{
    ICollection IRequestParameters.Values => Parameters;

    public List<T> Parameters { get; set; }

    public RequestParameters(params T[] parameters) : this((ICollection<T>)parameters)
    {
    }

    public RequestParameters(ICollection<T> parameters)
    {
        Parameters = [.. parameters];
    }
}

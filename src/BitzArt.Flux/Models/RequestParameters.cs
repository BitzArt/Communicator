namespace BitzArt.Flux;

public class RequestParameters(params object?[] parameters) : RequestParameters<object?>(parameters)
{
}

public class RequestParameters<T> : IRequestParameters<T>
{
    public ICollection<T> Parameters { get; init; } = [];

    public RequestParameters(params T[] parameters)
    {
        Parameters = parameters;
    }
}

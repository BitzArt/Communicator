namespace BitzArt.Flux;

public class RequestParameters : RequestParameters<object?>
{
    public RequestParameters(params object?[] parameters) : base(parameters)
    {
    }
}

public class RequestParameters<T> : IRequestParameters<T>
{
    public ICollection<T> Parameters { get; init; } = [];

    public RequestParameters(params T[] parameters)
    {
        Parameters = parameters;
    }
}

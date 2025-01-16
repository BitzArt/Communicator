namespace BitzArt.Flux;

public sealed class RequestParameters(params object?[] parameters) : RequestParameters<object?>(parameters)
{
}

public class RequestParameters<T>(params T[] parameters) : IRequestParameters<T>
{
    public ICollection<T> Parameters { get; init; } = parameters;
}

namespace BitzArt.Flux;

public class FluxRequestParameters : FluxRequestParameters<object?>
{
    public FluxRequestParameters(params object?[] parameters) : base(parameters)
    {
    }
}

public class FluxRequestParameters<T> : IFluxRequestParameters<T>
{
    public ICollection<T> Parameters { get; init; }

    public FluxRequestParameters(params T[] parameters)
    {
        Parameters = parameters;
    }
}

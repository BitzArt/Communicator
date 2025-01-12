namespace BitzArt.Flux;

public class FluxRequestParameters : FluxRequestParameters<object?>
{
}

public class FluxRequestParameters<T> : IFluxRequestParameters<T>
{
    public ICollection<T> Parameters { get; init; }

    public FluxRequestParameters(params T[] parameters) : this()
    {
        Parameters = parameters;
    }

    public FluxRequestParameters()
    {
        
    }
}

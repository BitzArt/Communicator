namespace BitzArt.Flux;

public interface IFluxRequestParameters<T> : IFluxRequestParameters
{
    public ICollection<T> Parameters { get; }
}

public interface IFluxRequestParameters
{ 
}
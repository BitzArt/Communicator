namespace BitzArt.Flux;

public class FluxRequestParameters(params object?[] parameters) : IFluxRequestParameters
{
    public object?[] Parameters = parameters;
}

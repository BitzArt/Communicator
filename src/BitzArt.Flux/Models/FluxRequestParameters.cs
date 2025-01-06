namespace BitzArt.Flux;

public record FluxRequestParameters
{
    public object?[] Parameters;

    public FluxRequestParameters(params object?[] parameters)
    {
        Parameters = parameters;
    }
}

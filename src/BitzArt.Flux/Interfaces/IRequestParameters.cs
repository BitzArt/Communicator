namespace BitzArt.Flux;

public interface IRequestParameters<T> : IRequestParameters
{
    public ICollection<T> Parameters { get; }
}

public interface IRequestParameters
{ 
}
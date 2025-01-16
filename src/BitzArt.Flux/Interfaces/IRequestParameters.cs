namespace BitzArt.Flux;

public interface IRequestParameters<T>
{
    public ICollection<T> Parameters { get; }
}

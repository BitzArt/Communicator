using System.Collections;

namespace BitzArt.Flux;

/// <summary>
/// Represents a collection of parameters to be used in an operation.
/// </summary>
public interface IRequestParameters
{
    /// <summary>
    /// A collection of parameters to be used in an operation.
    /// </summary>
    public ICollection Values { get; }
}

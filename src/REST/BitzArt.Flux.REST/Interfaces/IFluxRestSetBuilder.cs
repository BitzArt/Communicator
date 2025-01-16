using BitzArt.Flux.REST;

namespace BitzArt.Flux;

/// <summary>
/// Flux REST set builder.
/// </summary>
/// <typeparam name="TModel">
/// The model type of the set.
/// </typeparam>
/// <typeparam name="TKey">
/// The key type of the set.
/// </typeparam>
public interface IFluxRestSetBuilder<TModel, TKey> : IFluxRestServiceBuilder
    where TModel : class
{
    internal IFluxRestSetOptions<TModel> SetOptions { get; }

    /// <summary>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TParameters>(
        string endpoint)
        where TParameters : IRequestParameters
        => this.WithEndpoint<TModel, TKey, TParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TParameters>(
        string endpoint,
        Func<TParameters, RestRequestParameters> getParameters)
        where TParameters : IRequestParameters
        => this.WithEndpoint<TModel, TKey, TParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithEndpointExtension.WithEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithEndpoint<TInputParameters, TOutputParameters>(
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
        => this.WithEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    ///  <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TParameters>(
        string endpoint)
        where TParameters : IRequestParameters
        => this.WithPageEndpoint<TModel, TKey, TParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    ///  <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TParameters>(
        string endpoint,
        Func<TParameters, RestRequestParameters> getParameters)
        where TParameters : IRequestParameters
        => this.WithPageEndpoint<TModel, TKey, TParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    ///  <inheritdoc cref="WithPageEndpointExtension.WithPageEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetEndpointBuilder<TModel, TKey> WithPageEndpoint<TInputParameters, TOutputParameters>(
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
        => this.WithPageEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(string endpoint)
        where TParameters : IRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(endpoint);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<TKey?, string> getEndpoint)
        where TParameters : IRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(Func<TKey?, TParameters, string> getEndpoint)
        where TParameters : IRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        string endpoint,
        Func<TParameters, RestRequestParameters> getParameters)
        where TParameters : IRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        string endpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(endpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<string> getEndpoint,
        Func<TParameters, RestRequestParameters> getParameters)
        where TParameters : IRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        Func<string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<TKey?, string> getEndpoint,
        Func<TParameters, RestRequestParameters> getParameters)
        where TParameters : IRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        Func<TKey?, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TParameters>(
        Func<TKey?, TParameters, string> getEndpoint,
        Func<TParameters, RestRequestParameters> getParameters)
        where TParameters : IRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TParameters>(getEndpoint, getParameters);

    /// <summary>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="WithIdEndpointExtension.WithIdEndpoint{TModel, TKey}(IFluxRestSetBuilder{TModel, TKey}, string)"/>
    /// </returns>
    public IFluxRestSetIdEndpointBuilder<TModel, TKey> WithIdEndpoint<TInputParameters, TOutputParameters>(
        Func<TKey?, TInputParameters, string> getEndpoint,
        Func<TInputParameters, TOutputParameters> getParameters)
        where TInputParameters : IRequestParameters
        where TOutputParameters : IRestRequestParameters
        => this.WithIdEndpoint<TModel, TKey, TInputParameters, TOutputParameters>(getEndpoint, getParameters);
}

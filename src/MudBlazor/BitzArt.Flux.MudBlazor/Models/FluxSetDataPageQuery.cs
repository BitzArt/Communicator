using BitzArt.Json;
using BitzArt.Pagination;
using MudBlazor;
using System.Text.Json.Serialization;

namespace BitzArt.Flux.MudBlazor;

/// <summary>
/// Represents a page query for a data set.
/// </summary>
public record FluxSetDataPageQuery<TModel>
    where TModel : class
{
    /// <summary>
    /// Table state at the time of request.
    /// </summary>
    public TableState TableState { get; set; } = null!;

    /// <summary>
    /// Parameters for the request.
    /// </summary>
    [JsonConverter(typeof(ItemConverter<TypedObjectJsonConverter<object>>))]
    public object[] Parameters { get; set; } = null!;

    /// <summary>
    /// Data returned by the request.
    /// </summary>
    public PageResult<TModel> Data { get; set; } = null!;

    /// <summary>
    /// Creates a new instance of <see cref="FluxSetDataPageQuery{TModel}"/>.
    /// </summary>
    public FluxSetDataPageQuery(TableState tableState, object[] parameters, PageResult<TModel> data) : this()
    {
        TableState = tableState;
        Parameters = parameters;
        Data = data;
    }

    /// <summary>
    /// Creates a new instance of <see cref="FluxSetDataPageQuery{TModel}"/>.
    /// </summary>
    public FluxSetDataPageQuery() { }
}

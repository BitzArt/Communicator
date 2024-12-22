using BitzArt.Pagination;
using MudBlazor;

namespace BitzArt.Flux.MudBlazor;

/// <summary>
/// Extension methods for <see cref="PageResult"/>.
/// </summary>
public static class PageResultExtensions
{
    /// <summary>
    /// Returns <see cref="TableData{TModel}"/>.
    /// </summary>
    public static TableData<TModel> ToTableData<TModel>(this PageResult<TModel> pageResult)
        where TModel : class
    {
        ArgumentNullException.ThrowIfNull(pageResult, nameof(pageResult));

        return new()
        {
            Items = pageResult.Items,
            TotalItems = pageResult.Total!.Value
        };
    }
}

﻿using BitzArt.Pagination;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;

namespace BitzArt.Flux.MudBlazor;

// TODO: ? Extract reset logic ?
// TODO: ? Extract page state comparison logic ?
// TODO: Cleanup and refactor

internal class FluxSetDataProvider<TModel> : IFluxSetDataProvider<TModel>
    where TModel : class
{
    public IFluxSetContext<TModel> SetContext { get; internal set; } = null!;

    public Func<TableState, CancellationToken, Task<TableData<TModel>>> Data => GetDataAsync;

    public Func<TableState, object[]>? GetParameters { get; set; } = null;

    public FluxSetDataPageQuery<TModel>? LastQuery { get; private set; }

    private bool _resetting = false;

    private bool _resetPageOnce = false;
    private bool ResetPageOnce
    {
        get
        {
            if (_resetPageOnce == true)
            {
                _resetPageOnce = false;
                return true;
            }
            
            return false;
        }
        set => _resetPageOnce = value;
    }

    public void ResetPage()
    {
        ResetPageOnce = true;
    }

    public async Task ResetAndReloadAsync()
    {
        ResetPage();

        if (Table is null) throw new InvalidOperationException(
            "Table component must be forwarded to the flux data provider for it to be able to trigger a reload.");
        
        await Table!.ReloadServerData();
    }

    public Func<bool>? ShouldResetPage { get; set; }

    public bool ShouldResetPageOnOrderChanged { get; set; } = true;

    public bool ShouldResetPageOnOrderDirectionChanged { get; set; } = true;

    public Func<object[], object[], bool>? ShouldResetPageOnParameters { get; set; } = null;

    public MudTable<TModel>? Table { get; set; }

    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.")]
    public async Task<TableData<TModel>> GetDataAsync(TableState state, CancellationToken cancellationToken)
    {
        var parameters = GetParameters is not null ? GetParameters(state) : [];

        if (ShouldReset(state, parameters))
        {
            if (Table is null) throw new InvalidOperationException(
                "Table component must be forwarded to the flux data provider for it to be able to reset current page.");

            Table.CurrentPage = 0;
            _resetting = true;
            await Table.ReloadServerData();

            return LastQuery!.Result;
        }

        if (_resetting == true) _resetting = false;

        if (CompareWithLastRequest(state, parameters)) return LastQuery!.Result;

        var currentQuery = new FluxSetDataPageQuery<TModel>()
        {
            TableState = state,
            Parameters = parameters
        };
        var page = await SetContext.GetPageAsync(state.Page * state.PageSize, state.PageSize, parameters: parameters);
        var result = BuildTableData(page, currentQuery);

        LastQuery = currentQuery;

        return result;
    }

    private bool ShouldReset(TableState state, object[] newParameters)
    {
        // already resetting, do not loop infinitely
        if (_resetting) return false;

        // manual page reset requested
        if (ResetPageOnce) return true;

        // reset on order change
        if (ShouldResetOrderChanged(state)) return true;

        // reset on order direction change
        if (ShouldResetOrderDirectionChanged(state)) return true;

        // dynamic reset
        if (ShouldResetDynamic()) return true;

        // dynamic reset based on parameters
        if (ShouldResetDynamicOnParameters(newParameters)) return true;

        return false;
    }

    private bool ShouldResetOrderChanged(TableState newState) =>
        ShouldResetPageOnOrderChanged
        && LastQuery is not null
        && HasOrderChanged(LastQuery!.TableState, newState);

    private bool ShouldResetOrderDirectionChanged(TableState newState) =>
        ShouldResetPageOnOrderDirectionChanged
        && LastQuery is not null
        && HasOrderDirectionChanged(LastQuery.TableState, newState);

    private bool ShouldResetDynamic() =>
        ShouldResetPage is not null && ShouldResetPage.Invoke() == true;

    private bool ShouldResetDynamicOnParameters(object[] newParameters)
    {
        var lastParameters = LastQuery?.Parameters;

        return lastParameters is not null
            && ShouldResetPageOnParameters is not null
            && ShouldResetPageOnParameters!.Invoke(lastParameters, newParameters) == true;
    }


    private static bool HasOrderChanged(TableState lastState, TableState newState)
    {
        if (lastState.SortLabel != newState.SortLabel) return true;
        return false;
    }

    private static bool HasOrderDirectionChanged(TableState lastState, TableState newState)
    {
        if (lastState.SortDirection != newState.SortDirection) return true;
        return false;
    }

    private bool CompareWithLastRequest(TableState newState, object[] newParameters)
    {
        if (LastQuery is null) return false;

        var pageStateHasChanged = ComparePageStates(LastQuery!.TableState, newState) == false;
        if (pageStateHasChanged) return false;

        var parametersHaveChanged = CompareParameters(LastQuery!.Parameters, newParameters) == false;
        if (parametersHaveChanged) return false;

        return true;
    }

    private static bool ComparePageStates(TableState lastState, TableState newState)
    {
        if (lastState.Page != newState.Page) return false;

        if (lastState.PageSize != newState.PageSize) return false;

        return true;
    }

    private static bool CompareParameters(object[]? lastParameters, object[] newParameters)
    {
        if (lastParameters is null) return false;

        if (lastParameters.Length != newParameters.Length) return false;

        for (var i = 0; i < lastParameters.Length; i++)
        {
            if (!lastParameters[i].Equals(newParameters[i])) return false;
        }

        return true;
    }

    private static TableData<TModel> BuildTableData(PageResult<TModel> page, FluxSetDataPageQuery<TModel> currentQuery)
    {
        var result = new TableData<TModel>()
        {
            Items = page.Data,
            TotalItems = page.Total!.Value
        };

        currentQuery.Result = result;

        return result;
    }
}

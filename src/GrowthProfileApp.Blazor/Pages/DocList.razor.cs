using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using GrowthProfileApp.Documents;
using Volo.Abp.Application.Dtos;

namespace GrowthProfileApp.Blazor.Pages;

public partial class DocList
{
    private IReadOnlyList<BasicInfoDocumentDto> InfoList { get; set; }

    private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
    private int CurrentPage { get; set; }
    private string CurrentSorting { get; set; }
    private int TotalCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetListAsync();
    }

    private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<BasicInfoDocumentDto> e)
    {
        CurrentSorting = e.Columns
            .Where(c => c.SortDirection != SortDirection.Default)
            .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
            .JoinAsString(",");
        CurrentPage = e.Page - 1;

        await GetListAsync();

        await InvokeAsync(StateHasChanged);
    }
    
    private async Task GetListAsync()
    {
        var result = await Service.GetListAsync(
            new GetBasicInfoListDto
            {
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
            }
        );

        InfoList = result.Items;
        TotalCount = (int)result.TotalCount;
    }

    private void NavigateToAudit(string id)
    {
        NavMgr.NavigateTo("/Document/Audit/" + id);
    }
}
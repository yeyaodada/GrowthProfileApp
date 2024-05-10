using Volo.Abp.Application.Dtos;

namespace GrowthProfileApp.Documents;

public class GetBasicInfoListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GrowthProfileApp.Manager;

public interface IInfoAppService : IApplicationService
{
    Task<BasicInfoDocumentDto> GetAsync(Guid id);

    Task<PagedResultDto<BasicInfoDocumentDto>> GetListAsync(GetBasicInfoListDto dto);

    Task<BasicInfoDocumentDto?> GetByUserAsync(Guid userId);

    Task<BasicInfoDocumentDto> CreateAsync();
}
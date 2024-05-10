using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GrowthProfileApp.Documents;

public interface IProfileDocumentService : ICrudAppService<
    ProfileDocumentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProfileDocumentDto>
{
    
}
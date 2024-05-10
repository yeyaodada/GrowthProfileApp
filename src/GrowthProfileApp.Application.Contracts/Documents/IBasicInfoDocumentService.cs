using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GrowthProfileApp.Documents;

public interface IBasicInfoDocumentService : ICrudAppService<
    BasicInfoDocumentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBasicInfoDocumentDto>
{
    
}
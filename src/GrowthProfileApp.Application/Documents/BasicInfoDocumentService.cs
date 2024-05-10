using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GrowthProfileApp.Documents;

public class BasicInfoDocumentService : CrudAppService<
    BasicInfoDocument, BasicInfoDocumentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBasicInfoDocumentDto>, IBasicInfoDocumentService
{
    public BasicInfoDocumentService(IRepository<BasicInfoDocument, Guid> repository) : base(repository)
    {
        
    }
}
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GrowthProfileApp.Documents;

public class ProfileDocumentService : CrudAppService<
    ProfileDocument, ProfileDocumentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProfileDocumentDto>, IProfileDocumentService
{
    public ProfileDocumentService(IRepository<ProfileDocument, Guid> repository) : base(repository)
    {
        
    }
}
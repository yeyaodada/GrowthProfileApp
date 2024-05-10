using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using Volo.Abp.Application.Services;

namespace GrowthProfileApp.Manager;

public interface IDocumentAppService : IApplicationService
{
    Task<ProfileDocumentDto> GetAsync(Guid guid);

    Task<Boolean> HasDocument(ProfileDocumentType type, Guid? userId = null);
    
    Task<ProfileDocumentDto?> FindByUserIDAsync(Guid userId, ProfileDocumentType type);

    Task<ProfileDocumentDto> CreateAsync(ProfileDocumentType type);

    Task UpdateAsync(CreateUpdateProfileDocumentDto dto);
}
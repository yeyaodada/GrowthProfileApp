using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using Volo.Abp.Domain.Services;

namespace GrowthProfileApp.Manager;

public class DocumentManager : DomainService
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentManager(IDocumentRepository repository)
    {
        this._documentRepository = repository;
    }
    
    public async Task<ProfileDocument> CreateAsync(Guid userId, ProfileDocumentType type)
    {
        var existing = await _documentRepository.FindByUserID(userId, type);
        if (existing != null)
        {
            throw new Exception("已存在现有！请尝试更新！");
        }

        return new ProfileDocument(userId, type);
    }
}
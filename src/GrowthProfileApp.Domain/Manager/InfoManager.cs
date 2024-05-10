using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using Volo.Abp.Domain.Services;

namespace GrowthProfileApp.Manager;

public class InfoManager : DomainService
{
    private readonly IInfoRepository _infoRepository;

    public InfoManager(IInfoRepository repository)
    {
        this._infoRepository = repository;
    }

    public async Task<BasicInfoDocument> CreateAsync(Guid userId)
    {
        var existing = await _infoRepository.FindByUserID(userId);
        if (existing != null)
        {
            throw new Exception("已存在现有！请尝试更新！");
        }

        return new BasicInfoDocument(userId);
    }
}
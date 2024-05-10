using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using GrowthProfileApp.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace GrowthProfileApp.Manager;

public class InfoAppService : GrowthProfileAppAppService, IInfoAppService
{
    private readonly IInfoRepository _infoRepository;
    private readonly InfoManager _infoManager;

    public InfoAppService(IInfoRepository _repository, InfoManager _manager)
    {
        _infoManager = _manager;
        _infoRepository = _repository;
    }

    public async Task<BasicInfoDocumentDto> GetAsync(Guid id)
    {
        var obj = await _infoRepository.GetAsync(id);
        return ObjectMapper.Map<BasicInfoDocument, BasicInfoDocumentDto>(obj);
    }

    public async Task<PagedResultDto<BasicInfoDocumentDto>> GetListAsync(GetBasicInfoListDto dto)
    {
        if (dto.Sorting.IsNullOrWhiteSpace())
        {
            dto.Sorting = nameof(BasicInfoDocument.Name);
        }

        var result = await _infoRepository.GetInfoListAsync(
            dto.SkipCount,
            dto.MaxResultCount,
            dto.Sorting,
            dto.Filter
        );

        var total = dto.Filter == null
            ? await _infoRepository.CountAsync()
            : await _infoRepository.CountAsync(
                a => a.Name.Contains(dto.Filter));

        return new PagedResultDto<BasicInfoDocumentDto>(total,
            ObjectMapper.Map<List<BasicInfoDocument>, List<BasicInfoDocumentDto>>(result));
    }

    public async Task<BasicInfoDocumentDto?> GetByUserAsync(Guid userId)
    {
        var obj = await _infoRepository.FindByUserID(userId);
        return ObjectMapper.Map<BasicInfoDocument, BasicInfoDocumentDto>(obj);
    }

    public async Task<BasicInfoDocumentDto> CreateAsync()
    {
        Guid userId = CurrentUser.Id ?? Guid.Empty;

        var obj = await _infoManager.CreateAsync(userId);
        obj.Name = CurrentUser.Name ?? String.Empty;
        obj.Birthday = DateTime.Now;
        await _infoRepository.InsertAsync(obj);

        return ObjectMapper.Map<BasicInfoDocument, BasicInfoDocumentDto>(obj);
    }

    public async Task UpdateAsync(CreateUpdateBasicInfoDocumentDto dto)
    {
        var userId = CurrentUser.Id ?? Guid.Empty;

        var obj = await _infoRepository.FindByUserID(userId);

        if (obj == null)
        {
            return;
        }

        obj.Name = dto.Name;
        obj.Address = dto.Address;
        obj.Nation = dto.Nation;
        obj.Birthday = dto.Birthday;
        obj.PoliticalStatus = dto.PoliticalStatus;
        obj.Faculty = dto.Faculty;
        obj.Profession = dto.Profession;
        obj.Class = dto.Class;
        obj.FamilyStatus = dto.FamilyStatus;
        obj.FamilyDescription = dto.FamilyDescription;
        obj.GrowthEnvironmentDescription = dto.GrowthEnvironmentDescription;
        obj.SelfIntroduction = dto.SelfIntroduction;

        await _infoRepository.UpdateAsync(obj);
    }
}
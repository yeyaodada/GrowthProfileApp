using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;

namespace GrowthProfileApp.Blazor.Pages;

public partial class InfoEditor
{
    private bool _savedAlertVisible = false;

    private DateTime? _birthday = DateTime.Now;

    private BasicInfoDocumentDto _obj = new BasicInfoDocumentDto();

    protected override async Task OnInitializedAsync()
    {
        await Refresh();
    }

    private async Task Refresh()
    {
        if (CurrentUser.Id == null)
        {
            return;
        }

        _obj = await Service.GetByUserAsync(CurrentUser.Id ?? Guid.Empty) ?? new BasicInfoDocumentDto();
        _birthday = _obj.Birthday;
    }

    private async Task Save()
    {
        if (CurrentUser.Id == null)
        {
            return;
        }
        
        if (await Service.GetByUserAsync(CurrentUser.Id ?? Guid.Empty) == null)
        {
            await Service.CreateAsync();
        }
        var updateDto = new CreateUpdateBasicInfoDocumentDto
        {
            UserID = CurrentUser.Id ?? Guid.Empty,
            Name = _obj.Name,
            Nation = _obj.Nation,
            PoliticalStatus = _obj.PoliticalStatus,
            Faculty = _obj.Faculty,
            Profession = _obj.Profession,
            Class = _obj.Class,
            Address = _obj.Address,
            FamilyStatus = _obj.FamilyStatus,
            FamilyDescription = _obj.FamilyDescription,
            GrowthEnvironmentDescription = _obj.GrowthEnvironmentDescription,
            SelfIntroduction = _obj.SelfIntroduction,
            Birthday = _birthday ?? DateTime.Now
        };
        await Service.UpdateAsync(updateDto);
        await Refresh();

        _savedAlertVisible = true;
    }
}
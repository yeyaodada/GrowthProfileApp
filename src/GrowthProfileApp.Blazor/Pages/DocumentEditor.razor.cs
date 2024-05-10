using System;
using System.Threading.Tasks;
using Blazorise;
using GrowthProfileApp.Documents;
using Microsoft.AspNetCore.Components;

namespace GrowthProfileApp.Blazor.Pages;

public partial class DocumentEditor
{
    private ProfileDocumentDto _obj = new();
    private bool _savedAlertVisible;

    [Parameter] public int Term { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await Refresh();
    }

    private async Task Refresh()
    {
        var type = ProfileDocumentType.TERM_1;
        switch (Term)
        {
            case 1:
                type = ProfileDocumentType.TERM_1;
                break;
            case 2:
                type = ProfileDocumentType.TERM_2;
                break;
            case 3:
                type = ProfileDocumentType.TERM_3;
                break;
            case 4:
                type = ProfileDocumentType.TERM_4;
                break;
        }

        var my = await Service.GetByUserAsync(type) ?? new ProfileDocumentDto();

        _obj = my;
    }

    private async Task Save()
    {
        var userId = CurrentUser.Id;
        if (userId == null)
        {
            return;
        }
        
        var type = ProfileDocumentType.TERM_1;
        switch (Term)
        {
            case 1:
                type = ProfileDocumentType.TERM_1;
                break;
            case 2:
                type = ProfileDocumentType.TERM_2;
                break;
            case 3:
                type = ProfileDocumentType.TERM_3;
                break;
            case 4:
                type = ProfileDocumentType.TERM_4;
                break;
        }

        if (await Service.GetByUserAsync(type) == null)
        {
            await Service.CreateAsync(type);
        }
        
        var dto = new CreateUpdateProfileDocumentDto
        {
            DocumentType = type,
            UserID = userId ?? Guid.Empty,
            AwardGoal = _obj.AwardGoal,
            LearningGoal = _obj.LearningGoal,
            ExamGoal = _obj.ExamGoal,
            PoliticalGoal = _obj.PoliticalGoal,
            RoleGoal = _obj.RoleGoal,
            ClubGoal = _obj.ClubGoal,
            ReadingGoal = _obj.ReadingGoal,
            SocialCreditGoal = _obj.SocialCreditGoal,
            ExerciseGoal = _obj.ExerciseGoal,
            ShowOffGoal = _obj.ShowOffGoal,
            OtherGoal = _obj.OtherGoal,
            TermSummary = _obj.TermSummary,
            TeacherComment = _obj.TeacherComment,
            
            ScoreA = _obj.ScoreA,
            ScoreB = _obj.ScoreB,
            ScoreC = _obj.ScoreC,
            ScoreD = _obj.ScoreD,
            ScoreE = _obj.ScoreE
        };

        // Call the UpdateAsync method of the Service to save the changes
        await Service.UpdateAsync(dto);

        _savedAlertVisible = true;
    }
    
    private void NavigateToDownload()
    {
        NavMgr.NavigateTo("/DownloadPdf/" + CurrentUser.Id + "/" + Term);
    }
}
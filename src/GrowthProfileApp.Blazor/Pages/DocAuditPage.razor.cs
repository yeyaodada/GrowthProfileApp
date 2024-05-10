using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using Microsoft.AspNetCore.Components;

namespace GrowthProfileApp.Blazor.Pages;

enum DisplayDocType
{
    BASIC_INFO,
    PROFILE_DOC,
}

public partial class DocAuditPage : ComponentBase
{
    private bool _savedAlertVisible = false;
    
    [Parameter] public string UserId { get; set; }
    
    private ProfileDocumentDto? _obj = new ProfileDocumentDto();

    private Guid GuidUserId;

    private DisplayDocType _displayingDocType = DisplayDocType.BASIC_INFO;

    private ProfileDocumentType _profileDocumentType = ProfileDocumentType.TERM_1;

    private BasicInfoDocumentDto? _basicInfo = new BasicInfoDocumentDto();

    protected override async Task OnParametersSetAsync()
    {
        GuidUserId = Guid.Parse(UserId);

        _basicInfo = await InfoService.GetByUserAsync(GuidUserId);

        await RefreshDoc();
    }

    private async Task SetDisplayingDoc(int id)
    {
        switch (id)
        {
            case -1:
                _displayingDocType = DisplayDocType.BASIC_INFO;
                break;
            case 0:
                _displayingDocType = DisplayDocType.PROFILE_DOC;
                _profileDocumentType = ProfileDocumentType.TERM_1;
                break;
            case 1:
                _displayingDocType = DisplayDocType.PROFILE_DOC;
                _profileDocumentType = ProfileDocumentType.TERM_2;
                break;
            case 2:
                _displayingDocType = DisplayDocType.PROFILE_DOC;
                _profileDocumentType = ProfileDocumentType.TERM_3;
                break;
            case 3:
                _displayingDocType = DisplayDocType.PROFILE_DOC;
                _profileDocumentType = ProfileDocumentType.TERM_4;
                break;
        }

        await RefreshDoc();
    }

    private async Task RefreshDoc()
    {
        _obj = await DocService.FindByUserIDAsync(GuidUserId, _profileDocumentType);
    }

    private async Task Save()
    {
        var dto = new CreateUpdateProfileDocumentDto
        {
            DocumentType = _profileDocumentType,
            UserID = GuidUserId,
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

        await DocService.UpdateAsync(dto);
        await RefreshDoc();

        _savedAlertVisible = true;
    }
}
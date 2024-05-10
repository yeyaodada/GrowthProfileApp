using System;
using Volo.Abp.Application.Dtos;

namespace GrowthProfileApp.Documents;

public class ProfileDocumentDto : AuditedEntityDto<Guid>
{
    public Guid UserID { get; set; }

    public ProfileDocumentType DocumentType { get; set; }

    public string LearningGoal { get; set; }

    public string ExamGoal { get; set; }

    public string PoliticalGoal { get; set; }

    public string RoleGoal { get; set; }

    public string AwardGoal { get; set; }

    public string ClubGoal { get; set; }

    public string ReadingGoal { get; set; }

    public string SocialCreditGoal { get; set; }

    public string ExerciseGoal { get; set; }

    public string ShowOffGoal { get; set; }

    public string OtherGoal { get; set; }

    public string TermSummary {  get; set; }

    public string TeacherComment { get; set; }
    
    public int ScoreA { get; set; }
    
    public int ScoreB { get; set; }
    
    public int ScoreC { get; set; }
    
    public int ScoreD { get; set; }
    
    public int ScoreE { get; set; }
}
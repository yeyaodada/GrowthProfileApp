using System;
using System.ComponentModel.DataAnnotations;

namespace GrowthProfileApp.Documents;

public class CreateUpdateProfileDocumentDto
{
    [Required]
    public Guid UserID { get; set; } = Guid.Empty;

    [Required] public ProfileDocumentType DocumentType { get; set; } = ProfileDocumentType.TERM_1;
    
    [Required] 
    [StringLength(500)] 
    public string LearningGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string ExamGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string PoliticalGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string RoleGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string AwardGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string ClubGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string ReadingGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string SocialCreditGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string ExerciseGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string ShowOffGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string OtherGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string TermSummary { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string TeacherComment { get; set; } = string.Empty;

    [Required] 
    public int ScoreA { get; set; } = 0;
    
    [Required]
    public int ScoreB { get; set; } = 0;
    
    [Required]
    public int ScoreC { get; set; } = 0;
    
    [Required]
    public int ScoreD { get; set; } = 0;
    
    [Required]
    public int ScoreE { get; set; } = 0;
}
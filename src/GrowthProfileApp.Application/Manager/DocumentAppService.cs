using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;

namespace GrowthProfileApp.Manager;

public class DocumentAppService : GrowthProfileAppAppService, IDocumentAppService
{
    private readonly IDocumentRepository _repository;
    private readonly DocumentManager _manager;
    
    public DocumentAppService(IDocumentRepository _documentRepository, DocumentManager _documentManager)
    {
        _repository = _documentRepository;
        _manager = _documentManager;
    }

    public async Task<ProfileDocumentDto> GetAsync(Guid guid)
    {
        return ObjectMapper.Map<ProfileDocument, ProfileDocumentDto>(await _repository.GetAsync(guid));
    }
    
    public async Task<ProfileDocumentDto?> GetByUserAsync(ProfileDocumentType type)
    {
        if (CurrentUser.Id == null)
        {
            return null;
        }
        return ObjectMapper.Map<ProfileDocument?, ProfileDocumentDto?>(await _repository.FindByUserID(CurrentUser.Id ?? Guid.Empty, type));
    }

    public async Task<Boolean> HasDocument(ProfileDocumentType type, Guid? userId = null)
    {
        Guid actualId = userId ?? Guid.Empty;
        return await _repository.FindByUserID(actualId, type) == null;
    }

    public async Task<ProfileDocumentDto?> FindByUserIDAsync(Guid userId, ProfileDocumentType type)
    {
        var result = await _repository.FindByUserID(userId, type);
        return result == null ? null : ObjectMapper.Map<ProfileDocument, ProfileDocumentDto>(result);
    }

    public async Task<ProfileDocumentDto> CreateAsync(ProfileDocumentType type)
    {
        Guid userId = CurrentUser.Id ?? Guid.Empty;

        var obj = await _manager.CreateAsync(userId, type);
        await _repository.InsertAsync(obj);

        return ObjectMapper.Map<ProfileDocument, ProfileDocumentDto>(obj);
    }

    public async Task UpdateAsync(CreateUpdateProfileDocumentDto dto)
    {
        Guid userId = CurrentUser.Id ?? Guid.Empty;

        var obj = await _repository.FindByUserID(userId, dto.DocumentType);

        obj.LearningGoal = dto.LearningGoal;
        obj.ExamGoal = dto.ExamGoal;
        obj.PoliticalGoal = dto.PoliticalGoal;
        obj.RoleGoal = dto.RoleGoal;
        obj.AwardGoal = dto.AwardGoal;
        obj.ClubGoal = dto.ClubGoal;
        obj.ReadingGoal = dto.ReadingGoal;
        obj.SocialCreditGoal = dto.SocialCreditGoal;
        obj.ExerciseGoal = dto.ExerciseGoal;
        obj.ShowOffGoal = dto.ShowOffGoal;
        obj.OtherGoal = dto.OtherGoal;
        obj.TermSummary = dto.TermSummary;
        obj.TeacherComment = dto.TeacherComment;

        obj.ScoreA = dto.ScoreA;
        obj.ScoreB = dto.ScoreB;
        obj.ScoreC = dto.ScoreC;
        obj.ScoreD = dto.ScoreD;
        obj.ScoreE = dto.ScoreE;

        await _repository.UpdateAsync(obj);
    }
}
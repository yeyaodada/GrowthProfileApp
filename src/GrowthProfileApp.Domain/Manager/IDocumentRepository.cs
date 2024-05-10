using System;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using Volo.Abp.Domain.Repositories;

namespace GrowthProfileApp.Manager;

public interface IDocumentRepository : IRepository<ProfileDocument, Guid>
{
    Task<ProfileDocument?> FindByUserID(Guid id, ProfileDocumentType type);
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using Volo.Abp.Domain.Repositories;

namespace GrowthProfileApp.Manager;

public interface IInfoRepository : IRepository<BasicInfoDocument, Guid>
{
    Task<BasicInfoDocument?> FindByUserID(Guid id);

    Task<List<BasicInfoDocument>> GetInfoListAsync(int skipping, int max, string sorting, string filter = null);
}
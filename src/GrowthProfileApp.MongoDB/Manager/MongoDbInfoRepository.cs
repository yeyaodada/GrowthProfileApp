using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using GrowthProfileApp.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace GrowthProfileApp.Manager;

public class MongoDbInfoRepository
    : MongoDbRepository<GrowthProfileAppMongoDbContext, BasicInfoDocument, Guid>,
        IInfoRepository
{
    public MongoDbInfoRepository(
        IMongoDbContextProvider<GrowthProfileAppMongoDbContext> dbContextProvider
    ) : base(dbContextProvider)
    {
    }

    public async Task<BasicInfoDocument?> FindByUserID(Guid id)
    {
        var queryable = await GetMongoQueryableAsync();
        return await queryable.FirstOrDefaultAsync(i => i.UserID == id);
    }

    public async Task<List<BasicInfoDocument>> GetInfoListAsync(int skipping, int max, string sorting, string filter = null)
    {
        return await (await GetMongoQueryableAsync())
            .WhereIf<BasicInfoDocument, IMongoQueryable<BasicInfoDocument>>(
                !filter.IsNullOrWhiteSpace(), i => i.Name.Contains(filter)
            )
            .OrderBy(sorting)
            .As<IMongoQueryable<BasicInfoDocument>>()
            .Skip(skipping)
            .Take(max)
            .ToListAsync();
    }
}
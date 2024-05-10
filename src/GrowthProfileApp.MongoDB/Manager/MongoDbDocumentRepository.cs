using System;
using System.Threading;
using System.Threading.Tasks;
using GrowthProfileApp.Documents;
using GrowthProfileApp.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace GrowthProfileApp.Manager;

public class MongoDbDocumentRepository
    : MongoDbRepository<GrowthProfileAppMongoDbContext, ProfileDocument, Guid>,
        IDocumentRepository
{
    public MongoDbDocumentRepository(
        IMongoDbContextProvider<GrowthProfileAppMongoDbContext> dbContextProvider
    ) : base(dbContextProvider)
    {
    }

    public async Task<ProfileDocument?> FindByUserID(Guid id, ProfileDocumentType type)
    {
        var queryable = await GetMongoQueryableAsync();
        return await queryable.FirstOrDefaultAsync(i => i.UserID == id && i.DocumentType == type);
    }
}
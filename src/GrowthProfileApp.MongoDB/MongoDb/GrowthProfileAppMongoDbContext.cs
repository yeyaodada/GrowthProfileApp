using GrowthProfileApp.Documents;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace GrowthProfileApp.MongoDB;

[ConnectionStringName("Default")]
public class GrowthProfileAppMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    public IMongoCollection<ProfileDocument> ProfileDocuments => Collection<ProfileDocument>();
    public IMongoCollection<BasicInfoDocument> BasicInfoDocuments => Collection<BasicInfoDocument>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}

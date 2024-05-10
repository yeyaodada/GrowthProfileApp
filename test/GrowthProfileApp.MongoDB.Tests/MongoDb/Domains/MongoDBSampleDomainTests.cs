using GrowthProfileApp.Samples;
using Xunit;

namespace GrowthProfileApp.MongoDB.Domains;

[Collection(GrowthProfileAppTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<GrowthProfileAppMongoDbTestModule>
{

}

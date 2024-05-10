using GrowthProfileApp.MongoDB;
using GrowthProfileApp.Samples;
using Xunit;

namespace GrowthProfileApp.MongoDb.Applications;

[Collection(GrowthProfileAppTestConsts.CollectionDefinitionName)]
public class MongoDBSampleAppServiceTests : SampleAppServiceTests<GrowthProfileAppMongoDbTestModule>
{

}

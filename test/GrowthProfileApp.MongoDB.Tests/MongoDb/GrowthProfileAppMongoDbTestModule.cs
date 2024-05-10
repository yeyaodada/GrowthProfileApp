using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace GrowthProfileApp.MongoDB;

[DependsOn(
    typeof(GrowthProfileAppApplicationTestModule),
    typeof(GrowthProfileAppMongoDbModule)
)]
public class GrowthProfileAppMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = GrowthProfileAppMongoDbFixture.GetRandomConnectionString();
        });
    }
}

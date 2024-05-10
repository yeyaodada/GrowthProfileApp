using GrowthProfileApp.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace GrowthProfileApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(GrowthProfileAppMongoDbModule),
    typeof(GrowthProfileAppApplicationContractsModule)
    )]
public class GrowthProfileAppDbMigratorModule : AbpModule
{
}

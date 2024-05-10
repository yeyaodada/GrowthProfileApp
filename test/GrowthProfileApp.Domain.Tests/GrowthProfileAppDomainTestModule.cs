using Volo.Abp.Modularity;

namespace GrowthProfileApp;

[DependsOn(
    typeof(GrowthProfileAppDomainModule),
    typeof(GrowthProfileAppTestBaseModule)
)]
public class GrowthProfileAppDomainTestModule : AbpModule
{

}

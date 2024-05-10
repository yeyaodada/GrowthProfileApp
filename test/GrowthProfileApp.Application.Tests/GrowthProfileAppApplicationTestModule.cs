using Volo.Abp.Modularity;

namespace GrowthProfileApp;

[DependsOn(
    typeof(GrowthProfileAppApplicationModule),
    typeof(GrowthProfileAppDomainTestModule)
)]
public class GrowthProfileAppApplicationTestModule : AbpModule
{

}

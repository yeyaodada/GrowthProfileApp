using Volo.Abp.Modularity;

namespace GrowthProfileApp;

public abstract class GrowthProfileAppApplicationTestBase<TStartupModule> : GrowthProfileAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

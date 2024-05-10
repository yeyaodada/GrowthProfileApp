using Volo.Abp.Modularity;

namespace GrowthProfileApp;

/* Inherit from this class for your domain layer tests. */
public abstract class GrowthProfileAppDomainTestBase<TStartupModule> : GrowthProfileAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

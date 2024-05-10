using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace GrowthProfileApp.Blazor;

[Dependency(ReplaceServices = true)]
public class GrowthProfileAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "GrowthProfileApp";
}

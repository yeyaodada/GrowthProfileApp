using GrowthProfileApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace GrowthProfileApp.Blazor;

public abstract class GrowthProfileAppComponentBase : AbpComponentBase
{
    protected GrowthProfileAppComponentBase()
    {
        LocalizationResource = typeof(GrowthProfileAppResource);
    }
}

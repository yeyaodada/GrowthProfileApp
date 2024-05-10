using GrowthProfileApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GrowthProfileApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class GrowthProfileAppController : AbpControllerBase
{
    protected GrowthProfileAppController()
    {
        LocalizationResource = typeof(GrowthProfileAppResource);
    }
}

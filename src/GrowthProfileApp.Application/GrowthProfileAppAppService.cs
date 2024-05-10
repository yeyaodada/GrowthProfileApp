using System;
using System.Collections.Generic;
using System.Text;
using GrowthProfileApp.Localization;
using Volo.Abp.Application.Services;

namespace GrowthProfileApp;

/* Inherit your application services from this class.
 */
public abstract class GrowthProfileAppAppService : ApplicationService
{
    protected GrowthProfileAppAppService()
    {
        LocalizationResource = typeof(GrowthProfileAppResource);
    }
}

using Volo.Abp.Settings;

namespace GrowthProfileApp.Settings;

public class GrowthProfileAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(GrowthProfileAppSettings.MySetting1));
    }
}

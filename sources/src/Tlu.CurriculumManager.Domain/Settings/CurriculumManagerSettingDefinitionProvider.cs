using Volo.Abp.Settings;

namespace Tlu.CurriculumManager.Settings
{
    public class CurriculumManagerSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(CurriculumManagerSettings.MySetting1));
        }
    }
}

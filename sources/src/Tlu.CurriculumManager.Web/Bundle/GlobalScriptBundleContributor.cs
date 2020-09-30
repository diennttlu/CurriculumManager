using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tlu.CurriculumManager.Web.Bundle
{
    public class GlobalScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            //context.Files.Clear();
        }
    }
}

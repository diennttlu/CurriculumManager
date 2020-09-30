using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tlu.CurriculumManager.Web.Bundle
{
    public class GlobalStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/styles/card-body.css");
        }
    }
}

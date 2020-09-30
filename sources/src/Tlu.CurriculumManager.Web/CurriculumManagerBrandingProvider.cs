using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Tlu.CurriculumManager.Web
{
    [Dependency(ReplaceServices = true)]
    public class CurriculumManagerBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CurriculumManager";
    }
}

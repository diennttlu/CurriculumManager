using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Tlu.CurriculumManager.Web.Pages.Shared.Components.FluidContainer
{
    public class FluidContainerViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Pages/Shared/Components/FluidContainer/Default.cshtml");
        }
    }
}

using Tlu.CurriculumManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Tlu.CurriculumManager.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class CurriculumManagerController : AbpController
    {
        protected CurriculumManagerController()
        {
            LocalizationResource = typeof(CurriculumManagerResource);
        }
    }
}
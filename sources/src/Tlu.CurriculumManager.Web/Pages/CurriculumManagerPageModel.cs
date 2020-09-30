using Tlu.CurriculumManager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Tlu.CurriculumManager.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CurriculumManagerPageModel : AbpPageModel
    {
        protected CurriculumManagerPageModel()
        {
            LocalizationResourceType = typeof(CurriculumManagerResource);
        }
    }
}
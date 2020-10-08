using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Tlu.CurriculumManager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Tlu.CurriculumManager.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CurriculumManagerPageModel : AbpPageModel
    {
        private static readonly JsonSerializerSettings CamelCaseSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Include,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DateFormatHandling = DateFormatHandling.IsoDateFormat
        };

        protected CurriculumManagerPageModel()
        {
            LocalizationResourceType = typeof(CurriculumManagerResource);
        }

        protected string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, CamelCaseSerializerSettings);
        }

    }
}
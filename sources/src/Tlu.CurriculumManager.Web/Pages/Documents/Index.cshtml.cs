using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.Web.Pages.Documents
{
    public class IndexModel : CurriculumManagerPageModel
    {
        public void OnGet()
        {
            var inLibrany = Enum.GetValues(typeof(InLibrary)).Cast<InLibrary>().Select(v => new SelectListItem
                            {
                                Text = v.ToString(),
                                Value = ((int)v).ToString()
                            }).ToList();

            ViewData.Add("inLibrany", SerializeObject(inLibrany));
        }
    }
}

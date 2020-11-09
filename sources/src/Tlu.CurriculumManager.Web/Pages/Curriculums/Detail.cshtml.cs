using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tlu.CurriculumManager.SchoolYears;

namespace Tlu.CurriculumManager.Web.Pages.Curriculums
{
    public class DetailModel : CurriculumManagerPageModel
    {
        private readonly ISchoolYearAppService _schoolYearAppService;

        public DetailModel(ISchoolYearAppService schoolYearAppService)
        {
            _schoolYearAppService = schoolYearAppService;
        }
        public void OnGet()
        {
            var schoolYears = _schoolYearAppService.GetAllSelection();
            var allSchoolYears = schoolYears.Select(x => new SelectListItem()
            {
                Text = $"{x.Name}",
                Value = x.Id.ToString()
            }).ToList();
            ViewData.Add("allSchoolYears", SerializeObject(allSchoolYears));
        }
    }
}

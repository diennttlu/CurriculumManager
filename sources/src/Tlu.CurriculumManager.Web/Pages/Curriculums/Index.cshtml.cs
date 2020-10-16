using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Tlu.CurriculumManager.Majors;
using Tlu.CurriculumManager.SchoolYears;

namespace Tlu.CurriculumManager.Web.Pages.Curriculums
{
    public class IndexModel : CurriculumManagerPageModel
    {
        private readonly IMajorAppService _majorAppService;
        private readonly ISchoolYearAppService _schoolYearAppService;

        public IndexModel(IMajorAppService majorAppService, ISchoolYearAppService schoolYearAppService)
        {
            _majorAppService = majorAppService;
            _schoolYearAppService = schoolYearAppService;
        }

        public void OnGet()
        {
            var majors = _majorAppService.GetAllSelection();
            var schoolYears = _schoolYearAppService.GetAllSelection();
            var allMajors = majors.Select(x => new SelectListItem() 
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            var allSchoolYears = schoolYears.Select(x => new SelectListItem() 
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            ViewData.Add("allMajors", SerializeObject(allMajors));
            ViewData.Add("allSchoolYears", SerializeObject(allSchoolYears));
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Tlu.CurriculumManager.Documents;
using Tlu.CurriculumManager.SchoolYears;

namespace Tlu.CurriculumManager.Web.Pages.Outlines
{
    public class CreateModel : CurriculumManagerPageModel
    {
        private readonly ISchoolYearAppService _schoolYearAppService;
        private readonly IDocumentAppService _documentAppService;


        public CreateModel(
            ISchoolYearAppService schoolYearAppService,
            IDocumentAppService documentAppService)
        {
            _schoolYearAppService = schoolYearAppService;
            _documentAppService = documentAppService;
        }

        public void OnGet()
        {
            var schoolYears = _schoolYearAppService.GetAllSelection();
            var allSchoolYears = schoolYears.Select(item => new SelectListItem()
            {
                Text = $"{item.Name} - {item.Course}",
                Value = item.Id.ToString()
            });

            ViewData.Add("allSchoolYears", SerializeObject(allSchoolYears));
        }
    }
}

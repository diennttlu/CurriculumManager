using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.SchoolYears;

namespace Tlu.CurriculumManager.Web.Pages.SchoolYears
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public CreateUpdateSchoolYearDto SchoolYear { get; set; }

        private readonly ISchoolYearAppService _schoolYearAppService;

        public CreateModalModel(ISchoolYearAppService schoolYearAppService)
        {
            _schoolYearAppService = schoolYearAppService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _schoolYearAppService.CreateAsync(SchoolYear);
            return NoContent();
        }
    }
}

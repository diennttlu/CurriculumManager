using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.SchoolYears;

namespace Tlu.CurriculumManager.Web.Pages.SchoolYears
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateUpdateSchoolYearDto SchoolYear { get; set; }

        private readonly ISchoolYearAppService _schoolYearAppService;

        public EditModalModel(ISchoolYearAppService schoolYearAppService)
        {
            _schoolYearAppService = schoolYearAppService;
        }

        public async Task OnGetAsync()
        {
            var schoolYearDto = await _schoolYearAppService.GetAsync(Id);
            SchoolYear = ObjectMapper.Map<SchoolYearDto, CreateUpdateSchoolYearDto>(schoolYearDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _schoolYearAppService.UpdateAsync(Id, SchoolYear);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Faculties;

namespace Tlu.CurriculumManager.Web.Pages.Faculties
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateUpdateFacultyDto Faculty { get; set; }

        private readonly IFacultyAppService _facultyAppService;

        public EditModalModel(IFacultyAppService facultyAppService)
        {
            _facultyAppService = facultyAppService;
        }

        public async Task OnGetAsync()
        {
            var facultyDto = await _facultyAppService.GetAsync(Id);
            Faculty = ObjectMapper.Map<FacultyDto, CreateUpdateFacultyDto>(facultyDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _facultyAppService.UpdateAsync(Id, Faculty);
            return NoContent();
        }
    }
}

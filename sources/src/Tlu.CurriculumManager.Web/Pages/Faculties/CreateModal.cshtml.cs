using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Faculties;

namespace Tlu.CurriculumManager.Web.Pages.Faculties
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public CreateUpdateFacultyDto Faculty { get; set; }

        private readonly IFacultyAppService _facultyAppService;

        public CreateModalModel(IFacultyAppService facultyAppService)
        {
            _facultyAppService = facultyAppService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _facultyAppService.CreateAsync(Faculty);
            return NoContent();
        }
    }
}

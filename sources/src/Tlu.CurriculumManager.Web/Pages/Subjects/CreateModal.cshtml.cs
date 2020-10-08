using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Subjects;

namespace Tlu.CurriculumManager.Web.Pages.Subjects
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public CreateUpdateSubjectDto Subject { get; set; }

        private readonly ISubjectAppService _subjectAppService;

        public CreateModalModel(ISubjectAppService subjectAppService)
        {
            _subjectAppService = subjectAppService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _subjectAppService.CreateAsync(Subject);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Subjects;

namespace Tlu.CurriculumManager.Web.Pages.Subjects
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateUpdateSubjectDto Subject { get; set; }

        private readonly ISubjectAppService _subjectAppService;

        public EditModalModel(ISubjectAppService subjectAppService)
        {
            _subjectAppService = subjectAppService;
        }

        public async Task OnGetAsync()
        {
            var subjectDto = await _subjectAppService.GetAsync(Id);
            Subject = ObjectMapper.Map<SubjectDto, CreateUpdateSubjectDto>(subjectDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _subjectAppService.UpdateAsync(Id, Subject);
            return NoContent();
        }
    }
}

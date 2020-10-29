using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.SubjectGroups;
using static Tlu.CurriculumManager.Web.Pages.SubjectGroups.CreateModalModel;

namespace Tlu.CurriculumManager.Web.Pages.SubjectGroups
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateUpdateSubjectGroupDto SubjectGroup { get; set; }

        public List<SelectListItem> Curriculums { get; set; }

        private readonly ISubjectGroupAppService _subjectGroupAppService;

        public EditModalModel(
            ISubjectGroupAppService subjectGroupAppService)
        {
            _subjectGroupAppService = subjectGroupAppService;
        }

        public async Task OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _subjectGroupAppService.UpdateAsync(Id, SubjectGroup);
            return NoContent();
        }

    }
}

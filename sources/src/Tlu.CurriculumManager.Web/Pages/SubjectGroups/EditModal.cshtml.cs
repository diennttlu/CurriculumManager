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
        public SubjectGroupFormModel SubjectGroup { get; set; }

        public List<SelectListItem> Curriculums { get; set; }
        public List<SelectListItem> Parents { get; set; }

        private readonly ICurriculumAppService _curriculumAppService;
        private readonly ISubjectGroupAppService _subjectGroupAppService;

        public EditModalModel(
            ICurriculumAppService curriculumAppService,
            ISubjectGroupAppService subjectGroupAppService)
        {
            _curriculumAppService = curriculumAppService;
            _subjectGroupAppService = subjectGroupAppService;
        }

        public async Task OnGetAsync()
        {
            var curriculums = _curriculumAppService.GetAllSelection();
            Curriculums = curriculums.Select(x => new SelectListItem()
            {
                Text = $"{x.Name} - {x.SchoolYear.Course}",
                Value = x.Id.ToString()
            }).ToList();

            var subjectGroups = _subjectGroupAppService.GetAllSelection();
            Parents = subjectGroups.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            Parents.AddFirst(new SelectListItem() { Text = "--" });

            var subjectGroupDto = await _subjectGroupAppService.GetAsync(Id);
            SubjectGroup = ObjectMapper.Map<SubjectGroupDto, SubjectGroupFormModel>(subjectGroupDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var createUpdateSubjectGroupDto = ObjectMapper.Map<SubjectGroupFormModel, CreateUpdateSubjectGroupDto>(SubjectGroup);
            await _subjectGroupAppService.UpdateAsync(Id, createUpdateSubjectGroupDto);
            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.SubjectGroups;
using Tlu.CurriculumManager.Subjects;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Tlu.CurriculumManager.Web.Pages.SubjectGroups
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public SubjectGroupFormModel SubjectGroup { get; set; }

        public List<SelectListItem> Curriculums { get; set; }
        public List<SelectListItem> Parents { get; set; }

        private readonly ICurriculumAppService _curriculumAppService;
        private readonly ISubjectGroupAppService _subjectGroupAppService;

        public CreateModalModel(
            ICurriculumAppService curriculumAppService,
            ISubjectGroupAppService subjectGroupAppService)
        {
            _curriculumAppService = curriculumAppService;
            _subjectGroupAppService = subjectGroupAppService;
        }

        public void OnGet()
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
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var subjectGroupDto = ObjectMapper.Map<SubjectGroupFormModel, CreateUpdateSubjectGroupDto>(SubjectGroup);
            await _subjectGroupAppService.CreateAsync(subjectGroupDto);
            return NoContent();
        }

        public class SubjectGroupFormModel
        {
            [Required]
            public string Name { get; set; }

            [TextArea]
            public string Note { get; set; }

            [Required]
            [SelectItems(nameof(Curriculums))]
            [DisplayName("Chương trình đào tạo")]
            public int CurriculumId { get; set; }

            [SelectItems(nameof(Parents))]
            [DisplayName("Nhóm kiến thức cha")]
            public int? ParentId { get; set; }

            [DisplayName("Tổng số tin chỉ")]
            public int? UnitTotal { get; set; }
        }
    }
}

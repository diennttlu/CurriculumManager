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
        public CreateUpdateSubjectGroupDto SubjectGroup { get; set; }

        private readonly ISubjectGroupAppService _subjectGroupAppService;

        public CreateModalModel(
            ISubjectGroupAppService subjectGroupAppService)
        {;
            _subjectGroupAppService = subjectGroupAppService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _subjectGroupAppService.CreateAsync(SubjectGroup);
            return NoContent();
        }

        //public class SubjectGroupFormModel
        //{
        //    [Required]
        //    public string Name { get; set; }

        //    [TextArea]
        //    public string Note { get; set; }

        //    [Required]
        //    [SelectItems(nameof(Curriculums))]
        //    [DisplayName("Chương trình đào tạo")]
        //    public int CurriculumId { get; set; }

        //    [DisplayName("Nhóm kiến thức cha")]
        //    public int? ParentId { get; set; }

        //    [DisplayName("Tổng số tin chỉ")]
        //    public int? UnitTotal { get; set; }
        //}
    }
}

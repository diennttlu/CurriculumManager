using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.Majors;
using Tlu.CurriculumManager.SchoolYears;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Tlu.CurriculumManager.Web.Pages.Curriculums
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public CurriculumFormModel Curriculum { get; set; }

        public List<SelectListItem> Majors { get; set; }
        public List<SelectListItem> SchoolYears { get; set; }

        private readonly IMajorAppService _majorAppService;
        private readonly ISchoolYearAppService _schoolYearAppService;
        private readonly ICurriculumAppService _curriculumAppService;

        public CreateModalModel(
            IMajorAppService majorAppService, 
            ISchoolYearAppService schoolYearAppService,
            ICurriculumAppService curriculumAppService)
        {
            _majorAppService = majorAppService;
            _schoolYearAppService = schoolYearAppService;
            _curriculumAppService = curriculumAppService;
        }

        public void OnGet()
        {
            var majors = _majorAppService.GetAllSelection();
            var schoolYears = _schoolYearAppService.GetAllSelection().OrderByDescending(x => x.Id);
            Majors = majors.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            SchoolYears = schoolYears.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var curriculumDto = ObjectMapper.Map<CurriculumFormModel, CreateUpdateCurriculumDto>(Curriculum);
            await _curriculumAppService.CreateAsync(curriculumDto);
            return NoContent();
        }

        public class CurriculumFormModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public ApproveStatus ApproveStatus { get; set; }

            [Required]
            [DisplayName("Ngành học")]
            [SelectItems(nameof(Majors))]
            public int MajorId { get; set; }

            [Required]
            [DisplayName("Năm học")]
            [SelectItems(nameof(SchoolYears))]
            public int SchoolYearId { get; set; }
        }
    }
}

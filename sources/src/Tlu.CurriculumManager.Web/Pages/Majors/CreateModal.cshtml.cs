using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Majors;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Tlu.CurriculumManager.Web.Pages.Majors
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public MajorFormModel Major { get; set; }

        private readonly IMajorAppService _majorAppService;
        private readonly IFacultyAppService _facultyAppService;

        public List<SelectListItem> Faculties { get; set; }

        public CreateModalModel(
            IMajorAppService majorAppService,
            IFacultyAppService facultyAppService)
        {
            _majorAppService = majorAppService;
            _facultyAppService = facultyAppService;
        }

        public void OnGet()
        {
            Faculties = _facultyAppService.GetAllSelection().Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = $"{item.Id} - {item.Name}"
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var majorDto = ObjectMapper.Map<MajorFormModel, CreateUpdateMajorDto>(Major);
            await _majorAppService.CreateAsync(majorDto);
            return NoContent();
        }

        public class MajorFormModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            [SelectItems(nameof(Faculties))]
            public int FacultyId { get; set; }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Majors;
using static Tlu.CurriculumManager.Web.Pages.Majors.CreateModalModel;

namespace Tlu.CurriculumManager.Web.Pages.Majors
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public MajorFormModel Major { get; set; }

        public List<SelectListItem> Faculties { get; set; }

        private readonly IMajorAppService _majorAppService;
        private readonly IFacultyAppService _facultyAppService;

        public EditModalModel(
            IMajorAppService majorAppService,
            IFacultyAppService facultyAppService)
        {
            _majorAppService = majorAppService;
            _facultyAppService = facultyAppService;
        }

        public async Task OnGetAsync()
        {
            Faculties = _facultyAppService.GetAllSelection().Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = $"{item.Id} - {item.Name}"
            }).ToList();

            var majorDto = await _majorAppService.GetAsync(Id);
            Major = ObjectMapper.Map<MajorDto, MajorFormModel>(majorDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _majorAppService.UpdateAsync(Id, ObjectMapper.Map<MajorFormModel, CreateUpdateMajorDto>(Major));
            return NoContent();
        }
    }
}

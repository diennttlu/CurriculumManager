using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.Majors;
using Tlu.CurriculumManager.SchoolYears;
using static Tlu.CurriculumManager.Web.Pages.Curriculums.CreateModalModel;

namespace Tlu.CurriculumManager.Web.Pages.Curriculums
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CurriculumFormModel Curriculum { get; set; }

        public List<SelectListItem> Majors { get; set; }
        public List<SelectListItem> SchoolYears { get; set; }

        private readonly IMajorAppService _majorAppService;
        private readonly ISchoolYearAppService _schoolYearAppService;
        private readonly ICurriculumAppService _curriculumAppService;

        public EditModalModel(
            IMajorAppService majorAppService,
            ISchoolYearAppService schoolYearAppService,
            ICurriculumAppService curriculumAppService)
        {
            _majorAppService = majorAppService;
            _schoolYearAppService = schoolYearAppService;
            _curriculumAppService = curriculumAppService;
        }

        public async Task OnGetAsync()
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

            var curriculumDto = await _curriculumAppService.GetAsync(Id);
            Curriculum = ObjectMapper.Map<CurriculumDto, CurriculumFormModel>(curriculumDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _curriculumAppService.UpdateAsync(Id, ObjectMapper.Map<CurriculumFormModel, CreateUpdateCurriculumDto>(Curriculum));
            return NoContent();
        }
    }
}

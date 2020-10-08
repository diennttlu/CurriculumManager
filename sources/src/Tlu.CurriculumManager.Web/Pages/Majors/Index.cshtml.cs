using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Tlu.CurriculumManager.Faculties;

namespace Tlu.CurriculumManager.Web.Pages.Majors
{
    public class IndexModel : CurriculumManagerPageModel
    {
        private readonly IFacultyAppService _facultyAppService;

        public IndexModel(IFacultyAppService facultyAppService)
        {
            _facultyAppService = facultyAppService;
        }

        public void OnGet()
        {
            var faculties = _facultyAppService.GetAllSelection();
            var allFaculties = faculties.Select(item => new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });

            ViewData.Add("allFaculties", SerializeObject(allFaculties));
        }
    }
}

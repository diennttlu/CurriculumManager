using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Tlu.CurriculumManager.Curriculums;

namespace Tlu.CurriculumManager.Web.Pages.SubjectGroupDetails
{
    public class IndexModel : CurriculumManagerPageModel
    {
        private readonly ICurriculumAppService _curriculumAppService;

        public IndexModel(ICurriculumAppService curriculumAppService)
        {
            _curriculumAppService = curriculumAppService;
        }
        public void OnGet()
        {
            var curriculums = _curriculumAppService.GetAllSelection();
            var allCurriculums = curriculums.Select(x => new SelectListItem()
            {
                Text = $"{x.Name} - {x.SchoolYear.Course}",
                Value = x.Id.ToString()
            }).ToList();

            ViewData.Add("allCurriculums", SerializeObject(allCurriculums));

        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.SubjectGroups;

namespace Tlu.CurriculumManager.Web.Pages.SubjectGroups
{
    public class IndexModel : CurriculumManagerPageModel
    {
        private readonly ICurriculumAppService _curriculumAppService;
        private readonly ISubjectGroupAppService _subjectGroupAppService;

        public IndexModel(ICurriculumAppService curriculumAppService, ISubjectGroupAppService subjectGroupAppService)
        {
            _curriculumAppService = curriculumAppService;
            _subjectGroupAppService = subjectGroupAppService;
        }
        public void OnGet()
        {
            var curriculums = _curriculumAppService.GetAllSelection();
            var allCurriculums = curriculums.Select(x => new SelectListItem() 
            {
                Text = $"{x.Name} - {x.SchoolYear.Course}",
                Value = x.Id.ToString()
            }).ToList();

            var subjectGroups = _subjectGroupAppService
                .GetAllSelection()
                .Where(x => x.Childrens.Count > 0)
                .ToList();
            var allSubjectGroups = subjectGroups.Select(x => new SelectListItem() 
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            
            ViewData.Add("allCurriculums", SerializeObject(allCurriculums));
            ViewData.Add("allSubjectGroups", SerializeObject(allSubjectGroups));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.SubjectGroups;

namespace Tlu.CurriculumManager.Web.Pages.Curriculums
{
    public class DetailModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public List<SubjectGroupReportDto> SubjectGroupReports { get; set; }
        public CurriculumDto Curriculum { get; set; }

        private readonly ICurriculumAppService _curriculumAppService;

        public DetailModalModel(ICurriculumAppService curriculumAppService)
        {
            _curriculumAppService = curriculumAppService;
        }
        public async Task OnGetAsync()
        {
            SubjectGroupReports = await _curriculumAppService.GetSubjectGroupsByCurriculumId(Id);
            Curriculum = await _curriculumAppService.GetAsync(Id);
        }
    }
}

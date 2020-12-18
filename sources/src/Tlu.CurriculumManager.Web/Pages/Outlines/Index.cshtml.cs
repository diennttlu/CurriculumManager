using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Tlu.CurriculumManager.Documents;
using Tlu.CurriculumManager.SchoolYears;

namespace Tlu.CurriculumManager.Web.Pages.Outlines
{
    public class IndexModel : CurriculumManagerPageModel
    {
        private readonly ISchoolYearAppService _schoolYearAppService;
        private readonly IDocumentAppService _documentAppService;

        public IndexModel(ISchoolYearAppService schoolYearAppService, IDocumentAppService documentAppService)
        {
            _schoolYearAppService = schoolYearAppService;
            _documentAppService = documentAppService;
        }

        public void OnGet()
        {
            var schoolYears = _schoolYearAppService.GetAllSelection();
            var allSchoolYears = schoolYears.Select(item => new SelectListItem()
            {
                Text = $"{item.Name} - {item.Course}",
                Value = item.Id.ToString()
            }).ToList();

            var documents = _documentAppService.GetAllSelection();
            
            var allDocuments = documents.Select(item => new SelectListItem()
            {
                Text = $"{item.Name} - ISBN: {item.Isbn} - Thư viện: {item.LibraryCode}",
                Value = item.Id.ToString()
            }).ToList();

            allDocuments.AddFirst(new SelectListItem() { Text = "--", Value = null });

            ViewData.Add("allSchoolYears", SerializeObject(allSchoolYears));
            ViewData.Add("allDocuments", SerializeObject(allDocuments));
        }
    }
}

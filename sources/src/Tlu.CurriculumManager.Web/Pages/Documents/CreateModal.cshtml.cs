using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Documents;

namespace Tlu.CurriculumManager.Web.Pages.Documents
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public CreateUpdateDocumentDto Document { get; set; }

        private readonly IDocumentAppService _documentAppService;

        public CreateModalModel(IDocumentAppService documentAppService)
        {
            _documentAppService = documentAppService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _documentAppService.CreateAsync(Document);
            return NoContent();
        }
    }
}

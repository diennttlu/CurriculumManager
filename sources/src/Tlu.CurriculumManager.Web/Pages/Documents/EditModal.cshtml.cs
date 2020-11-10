using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Documents;

namespace Tlu.CurriculumManager.Web.Pages.Documents
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateUpdateDocumentDto Document { get; set; }

        private readonly IDocumentAppService _documentAppService;

        public EditModalModel(IDocumentAppService documentAppService)
        {
            _documentAppService = documentAppService;
        }

        public async Task OnGetAsync()
        {
            var documentDto = await _documentAppService.GetAsync(Id);
            Document = ObjectMapper.Map<DocumentDto, CreateUpdateDocumentDto>(documentDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _documentAppService.UpdateAsync(Id, Document);
            return NoContent();
        }
    }
}

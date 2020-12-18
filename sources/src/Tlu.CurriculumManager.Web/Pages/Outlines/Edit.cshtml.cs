using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Outlines;

namespace Tlu.CurriculumManager.Web.Pages.Outlines
{
    public class EditModel : CurriculumManagerPageModel
    {
        private readonly IOutlineAppService _outlineAppService;

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateUpdateOutlineDto Outline { get; set; }

        public EditModel(IOutlineAppService outlineAppService)
        {
            _outlineAppService = outlineAppService;
        }

        public async Task OnGetAsync()
        {
            var outlineDto = await _outlineAppService.GetAsync(Id);
            Outline = ObjectMapper.Map<OutlineDto, CreateUpdateOutlineDto>(outlineDto);
            ViewData.Add("outline", SerializeObject(Outline));
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _outlineAppService.UpdateAsync(Id, Outline);
            return RedirectToPage("/Outlines/Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Tlu.CurriculumManager.Outlines;

namespace Tlu.CurriculumManager.Web.Pages.Outlines
{
    public class DetailModalModel : CurriculumManagerPageModel
    {
        private readonly IOutlineAppService _outlineAppService;

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public OutlineDetailDto Outline { get; private set; }

        public DetailModalModel(IOutlineAppService outlineAppService)
        {
            _outlineAppService = outlineAppService;
        }
        public async void OnGet()
        {
            Outline = await _outlineAppService.GetDetailById(Id);
        }
    }
}

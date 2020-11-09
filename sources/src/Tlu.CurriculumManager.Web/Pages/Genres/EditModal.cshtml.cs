using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Genres;
using static Tlu.CurriculumManager.Web.Pages.Genres.CreateModalModel;

namespace Tlu.CurriculumManager.Web.Pages.Genres
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public GenreFormModel Genre { get; set; }

        public List<SelectListItem> Faculties { get; set; }

        private readonly IGenreAppService _genreAppService;
        private readonly IFacultyAppService _facultyAppService;

        public EditModalModel(
            IGenreAppService genreAppService,
            IFacultyAppService facultyAppService)
        {
            _genreAppService = genreAppService;
            _facultyAppService = facultyAppService;
        }

        public async Task OnGetAsync()
        {
            Faculties = _facultyAppService.GetAllSelection().Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = $"{item.Id} - {item.Name}"
            }).ToList();

            var genreDto = await _genreAppService.GetAsync(Id);
            Genre = ObjectMapper.Map<GenreDto, GenreFormModel>(genreDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _genreAppService.UpdateAsync(Id, ObjectMapper.Map<GenreFormModel, CreateUpdateGenreDto>(Genre));
            return NoContent();
        }
    }
}

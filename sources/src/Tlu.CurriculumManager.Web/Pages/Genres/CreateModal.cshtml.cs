using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Genres;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Tlu.CurriculumManager.Web.Pages.Genres
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public GenreFormModel Genre { get; set; }

        private readonly IGenreAppService _genreAppService;
        private readonly IFacultyAppService _facultyAppService;

        public List<SelectListItem> Faculties { get; set; }

        public CreateModalModel(
            IGenreAppService genreAppService,
            IFacultyAppService facultyAppService)
        {
            _genreAppService = genreAppService;
            _facultyAppService = facultyAppService;
        }

        public void OnGet()
        {
            Faculties = _facultyAppService.GetAllSelection().Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = $"{item.Id} - {item.Name}"
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var genreDto = ObjectMapper.Map<GenreFormModel, CreateUpdateGenreDto>(Genre);
            await _genreAppService.CreateAsync(genreDto);
            return NoContent();
        }

        public class GenreFormModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            [DisplayName("Khoa")]
            [SelectItems(nameof(Faculties))]
            public int FacultyId { get; set; }
        }
    }
}

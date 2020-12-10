using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.Genres;
using Tlu.CurriculumManager.Teachers;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Identity;

namespace Tlu.CurriculumManager.Web.Pages.Teachers
{
    public class CreateModalModel : CurriculumManagerPageModel
    {
        [BindProperty]
        public TeacherFormModel Teacher { get; set; }

        private readonly IGenreAppService _genreAppService;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly ITeacherAppService _teacherAppService;

        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Genres { get; set; }

        public CreateModalModel(
            IGenreAppService genreAppService, 
            IIdentityUserRepository identityUserRepository,
            ITeacherAppService teacherAppService)
        {
            _genreAppService = genreAppService;
            _identityUserRepository = identityUserRepository;
            _teacherAppService = teacherAppService;
        }
        public async Task OnGetAsync()
        {
            var users = await _identityUserRepository.GetListAsync();
            Users = users.Select(item => new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = $"{item.Surname} {item.Name}"
            }).ToList();
            Genres = _genreAppService.GetAllSelection().Select(item => new SelectListItem() 
            {
                Value = item.Id.ToString(),
                Text = $"{item.Id} - {item.Name}"
            }).ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var teacher = ObjectMapper.Map<TeacherFormModel, CreateUpdateTeacherDto>(Teacher);
            await _teacherAppService.CreateAsync(teacher);
            return NoContent();
        }

        public class TeacherFormModel
        {
            [Required]
            [DisplayName("User")]
            [SelectItems(nameof(Users))]
            public Guid UserId { get; set; }

            [Required]
            [DisplayName("Bộ môn")]
            [SelectItems(nameof(Genres))]
            public int GenreId { get; set; }

            [Required]
            [DisplayName("Chức vụ")]
            public Position Position { get; set; }

        }
    }
}

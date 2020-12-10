using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tlu.CurriculumManager.Genres;
using Tlu.CurriculumManager.Teachers;
using Volo.Abp.Identity;
using static Tlu.CurriculumManager.Web.Pages.Teachers.CreateModalModel;

namespace Tlu.CurriculumManager.Web.Pages.Teachers
{
    public class EditModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public TeacherFormModel Teacher { get; set; }

        private readonly IGenreAppService _genreAppService;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly ITeacherAppService _teacherAppService;

        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Genres { get; set; }

        public EditModalModel(
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
            await _teacherAppService.UpdateAsync(Id, teacher);
            return NoContent();
        }
    }
}

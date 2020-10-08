using System.Collections.Generic;
using Tlu.CurriculumManager.Genres;
using Tlu.CurriculumManager.Majors;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Faculties
{
    public class FacultyDto : EntityDto<int>
    {
        public string Name { get; set; }

        public virtual ICollection<MajorDto> Majors { get; set; }

        public virtual ICollection<GenreDto> Genres { get; set; }
    }
}

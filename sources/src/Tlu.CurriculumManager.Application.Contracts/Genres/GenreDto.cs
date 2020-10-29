using System.Collections.Generic;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Teachers;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Genres
{
    public class GenreDto : EntityDto<int>
    {
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public FacultyDto Faculty { get; set; }

        public ICollection<TeacherDto> Teachers { get; set; }
    }
}

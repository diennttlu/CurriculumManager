using System.Collections.Generic;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.Faculties;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Majors
{
    public class MajorDto : EntityDto<int>
    {
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public FacultyDto Faculty { get; set; }

        public ICollection<CurriculumDto> Curriculums { get; set; }
    }
}

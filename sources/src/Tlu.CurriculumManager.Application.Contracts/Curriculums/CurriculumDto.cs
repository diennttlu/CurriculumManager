using System.Collections.Generic;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.Majors;
using Tlu.CurriculumManager.SchoolYears;
using Tlu.CurriculumManager.SubjectGroups;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Curriculums
{
    public class CurriculumDto : EntityDto<int>
    {
        public string Name { get; set; }

        public int MajorId { get; set; }

        public int SchoolYearId { get; set; }

        public ApproveStatus ApproveStatus { get; set; }

        public MajorDto Major { get; set; }

        public SchoolYearDto SchoolYear { get; set; }

        public ICollection<SubjectGroupDto> SubjectGroups { get; set; }
    }
}

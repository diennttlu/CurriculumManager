using System.Collections.Generic;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.Outlines;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.SchoolYears
{
    public class SchoolYearDto : EntityDto<int>
    {
        public string Name { get; set; }

        public string Course { get; set; }

        public ICollection<CurriculumDto> Curriculums { get; set; }

        public ICollection<OutlineDto> Outlines { get; set; }
    }
}

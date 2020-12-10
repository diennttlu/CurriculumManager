using System.Collections.Generic;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.SubjectGroupDetails;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.SubjectGroups
{
    public class SubjectGroupDto : EntityDto<int>
    {
        public string Name { get; set; }

        public string Note { get; set; }

        public int DisplayOrder { get; set; }

        public int CurriculumId { get; set; }

        public CurriculumDto Curriculum { get; set; }

        public int? ParentId { get; set; }

        public SubjectGroupDto Parent { get; set; }

        public int? UnitTotal { get; set; }

        public ICollection<SubjectGroupDto> Childrens { get; set; }

        public ICollection<SubjectGroupDetailDto> SubjectGroupDetails { get; set; }
    }
}

using Tlu.CurriculumManager.SubjectGroups;
using Tlu.CurriculumManager.Subjects;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.SubjectGroupDetails
{
    public class SubjectGroupDetailDto : EntityDto<int>
    {
        public int SubjectId { get; set; }

        public int SubjectGroupId { get; set; }

        public virtual SubjectGroupDto SubjectGroup { get; set; }

        public virtual SubjectDto Subject { get; set; }
    }
}

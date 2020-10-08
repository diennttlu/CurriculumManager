using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class SubjectGroupDetail : Entity<int>
    {
        public int SubjectId { get; set; }

        public int SubjectGroupId { get; set; }

        public virtual SubjectGroup SubjectGroup { get;set; }

        public virtual Subject Subject { get; set; }
    }
}

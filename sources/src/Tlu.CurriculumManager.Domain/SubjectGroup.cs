using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class SubjectGroup : Entity<int> 
    {
        public int CurriculumDetailId { get; set; }

        public int SubjectId { get; set; }

        public virtual CurriculumDetail CurriculumDetail { get; set; }

        public virtual Subject Subject { get; set; }
    }
}

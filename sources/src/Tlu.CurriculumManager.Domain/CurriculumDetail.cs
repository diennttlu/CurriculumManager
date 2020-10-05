using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class CurriculumDetail : Entity<int>
    {
        public int CurriculumId { get; set; }

        public int KnowledgeGroupId { get; set; }

        public virtual Curriculum Curriculum { get; set; }

        public virtual KnowledgeGroup KnowledgeGroup { get; set; }

        public string Note { get; set; }

        public virtual ICollection<SubjectGroup> SubjectGroups { get; set; }

        public CurriculumDetail()
        {
            SubjectGroups = new HashSet<SubjectGroup>();
        }
    }
}

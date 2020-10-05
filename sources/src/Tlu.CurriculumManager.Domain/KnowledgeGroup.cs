using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class KnowledgeGroup : Entity<int>
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? DisplayOrder { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Modified { get; set; }

        public virtual ICollection<CurriculumDetail> CurriculumDetails { get; set; }

        public KnowledgeGroup()
        {
            CurriculumDetails = new HashSet<CurriculumDetail>();
        }
    }
}

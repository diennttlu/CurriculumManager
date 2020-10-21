using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class SubjectGroup : Entity<int> 
    {
        public string Name { get; set; }

        public string Note { get; set; }

        public int CurriculumId { get; set; }

        public int? ParentId { get; set; }

        public virtual SubjectGroup Parent { get; set; }

        public int? UnitTotal { get; set; }

        public virtual Curriculum Curriculum { get; set; }

        public ICollection<SubjectGroupDetail> SubjectGroupDetails { get; set; }

        public ICollection<SubjectGroup> Childrens { get; set; }

        public SubjectGroup()
        {
            SubjectGroupDetails = new HashSet<SubjectGroupDetail>();

            Childrens = new HashSet<SubjectGroup>();
        }

    }
}

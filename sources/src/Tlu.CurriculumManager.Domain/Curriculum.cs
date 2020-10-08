using System;
using System.Collections.Generic;
using Tlu.CurriculumManager.Enums;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Curriculum : Entity<int>
    {
        public string Name { get; set; }

        public int MajorId { get; set; }

        public int SchoolYearId { get; set; }

        public ApproveStatus ApproveStatus { get; set; }

        public virtual Major Major { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }
        
        public ICollection<SubjectGroup> SubjectGroups { get; set; }

        public Curriculum()
        {
            SubjectGroups = new HashSet<SubjectGroup>();
        }
    }
}

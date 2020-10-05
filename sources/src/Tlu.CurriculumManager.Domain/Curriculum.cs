using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Curriculum : Entity<int>
    {
        public string Name { get; set; }

        public int MajorId { get; set; }

        public int SchoolYearId { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Modified { get; set; }

        public virtual Major Major { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }

        public virtual ICollection<CurriculumDetail> CurriculumDetails { get; set; }

        public Curriculum()
        {
            CurriculumDetails = new HashSet<CurriculumDetail>();
        }
    }
}

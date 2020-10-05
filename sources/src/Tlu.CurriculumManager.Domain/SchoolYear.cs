using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class SchoolYear : Entity<int>
    {
        public string Name { get; set; }

        public string Course { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Modified { get; set; }

        public virtual ICollection<Curriculum> Curriculums { get; set; }
    }
}

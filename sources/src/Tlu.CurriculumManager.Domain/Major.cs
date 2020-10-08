using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Major : Entity<int>
    { 
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Curriculum> Curriculums { get; set; }

        public Major()
        {
            Curriculums = new HashSet<Curriculum>();
        }
    }
}

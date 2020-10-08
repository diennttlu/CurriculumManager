using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Faculty : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Major> Majors { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public Faculty()
        {
            Majors = new HashSet<Major>();
            Genres = new HashSet<Genre>();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Tlu.CurriculumManager.Enums;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Teacher : Entity<int>
    {
        public Guid UserId { get; set; }

        public int GenreId { get; set; }

        public Position Position { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

        public Teacher()
        {
            TeacherSubjects = new HashSet<TeacherSubject>();
        }
    }
}

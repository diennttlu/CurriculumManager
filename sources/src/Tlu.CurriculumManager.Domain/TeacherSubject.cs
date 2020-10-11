using System;
using Tlu.CurriculumManager.Users;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class TeacherSubject : Entity<int>
    {
        public int SubjectId { get; set; }

        public int TeacherId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}

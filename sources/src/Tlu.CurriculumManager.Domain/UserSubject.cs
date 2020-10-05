using System;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class UserSubject : Entity<int>
    {
        public int SubjectId { get; set; }

        public Guid UserId { get; set; }

        public virtual Subject Subject { get; set; }
    }
}

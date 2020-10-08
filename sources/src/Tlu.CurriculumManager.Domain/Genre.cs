using System.Collections.Generic;
using Tlu.CurriculumManager.Users;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Genre : Entity<int>
    {
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

    }
}

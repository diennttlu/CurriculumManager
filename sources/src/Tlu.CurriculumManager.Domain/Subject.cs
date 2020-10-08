using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Subject : Entity<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int Unit { get; set; }

        public string Condition { get; set; }

        public string HoursStudy { get; set; }

        public double Coefficient { get; set; }

        public virtual Outline Outline { get; set; }

        public virtual ICollection<UserSubject> UserSubjects { get; set; }

        public virtual ICollection<SubjectGroupDetail> SubjectGroupDetails { get; set; }

        public Subject()
        {
            UserSubjects = new HashSet<UserSubject>();
            SubjectGroupDetails = new HashSet<SubjectGroupDetail>();
        }
    }
}

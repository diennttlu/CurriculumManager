using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Subject : Entity<int>
    {
        [Column(TypeName = "varchar(100)")]
        public string Code { get; set; }

        public string Name { get; set; }

        public int Unit { get; set; }

        public string Condition { get; set; }

        public string HoursStudy { get; set; }

        public double Coefficient { get; set; }

        public virtual ICollection<Outline> Outlines { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

        public virtual ICollection<SubjectGroupDetail> SubjectGroupDetails { get; set; }

        public Subject()
        {
            Outlines = new HashSet<Outline>();
            TeacherSubjects = new HashSet<TeacherSubject>();
            SubjectGroupDetails = new HashSet<SubjectGroupDetail>();
        }
    }
}

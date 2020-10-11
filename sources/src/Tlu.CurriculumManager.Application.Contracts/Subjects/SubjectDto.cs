using System.Collections.Generic;
using Tlu.CurriculumManager.Outlines;
using Tlu.CurriculumManager.SubjectGroupDetails;
using Tlu.CurriculumManager.TeacherSubjects;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Subjects
{
    public class SubjectDto : EntityDto<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int Unit { get; set; }

        public string Condition { get; set; }

        public string HoursStudy { get; set; }

        public double Coefficient { get; set; }

        public ICollection<OutlineDto> Outlines { get; set; }

        public ICollection<TeacherSubjectDto> TeacherSubjects { get; set; }

        public ICollection<SubjectGroupDetailDto> SubjectGroupDetails { get; set; }
    }
}

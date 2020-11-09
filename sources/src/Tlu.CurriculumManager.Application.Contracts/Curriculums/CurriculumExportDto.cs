using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.SubjectGroups;
using Tlu.CurriculumManager.Subjects;

namespace Tlu.CurriculumManager.Curriculums
{
    public class CurriculumExportDto
    {
        public SubjectGroupDto SubjectGroup { get; set; }

        public List<SubjectDto> Subjects { get; set; }
    }
}

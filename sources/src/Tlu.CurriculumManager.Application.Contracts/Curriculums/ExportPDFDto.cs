using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.SubjectGroups;

namespace Tlu.CurriculumManager.Curriculums
{
    public class ExportPDFDto
    {
        public List<SubjectGroupReportDto> SubjectGroupReports { get; set; }

        public CurriculumDto Curriculum { get; set; }
    }
}

using System.Collections.Generic;
using Tlu.CurriculumManager.SubjectGroups;

namespace Tlu.CurriculumManager.Curriculums
{
    public class ExportCurriculumPDFDto
    {
        public List<SubjectGroupReportDto> SubjectGroupReports { get; set; }

        public CurriculumDto Curriculum { get; set; }
    }
}

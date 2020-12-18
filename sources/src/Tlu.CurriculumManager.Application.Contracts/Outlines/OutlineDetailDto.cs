using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.Documents;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.SchoolYears;
using Tlu.CurriculumManager.Subjects;

namespace Tlu.CurriculumManager.Outlines
{
    public class OutlineDetailDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Goal { get; set; }

        public string Assessment { get; set; }

        public string Content { get; set; }

        public ApproveStatus ApproveStatus { get; set; }

        public int SubjectId { get; set; }

        public int SchoolYearId { get; set; }

        public SubjectDto Subject { get; set; }

        public SchoolYearDto SchoolYear { get; set; }

        public List<DocumentShowOnOutlineDetail> Documents { get; set; }
    }
}

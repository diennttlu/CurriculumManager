using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.Outlines
{
    public class CreateUpdateOutlineDto
    {
        public string Goal { get; set; }

        public string Assessment { get; set; }

        public string Content { get; set; }

        public ApproveStatus ApproveStatus { get; set; }

        public int SubjectId { get; set; }

        public int OutlineId { get; set; }
    }
}

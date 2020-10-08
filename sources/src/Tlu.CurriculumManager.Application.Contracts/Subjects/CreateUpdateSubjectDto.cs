using System;
using System.ComponentModel.DataAnnotations;

namespace Tlu.CurriculumManager.Subjects
{
    public class CreateUpdateSubjectDto
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Unit { get; set; }

        public string Condition { get; set; }

        public string HoursStudy { get; set; }

        [Required]
        public double Coefficient { get; set; }
    }
}

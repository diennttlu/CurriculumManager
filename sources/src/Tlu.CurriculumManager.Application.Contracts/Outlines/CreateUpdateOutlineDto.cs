using System.ComponentModel.DataAnnotations;
using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.Outlines
{
    public class CreateUpdateOutlineDto
    {
        public string Description { get; set; }

        public string Goal { get; set; }

        public string Assessment { get; set; }

        public string Content { get; set; }

        [Required]
        public ApproveStatus ApproveStatus { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int SchoolYearId { get; set; }
    }
}

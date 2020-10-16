using System.ComponentModel.DataAnnotations;
using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.Curriculums
{
    public class CreateUpdateCurriculumDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int MajorId { get; set; }

        [Required]
        public int SchoolYearId { get; set; }

        [Required]
        public ApproveStatus ApproveStatus { get; set; }
    }
}

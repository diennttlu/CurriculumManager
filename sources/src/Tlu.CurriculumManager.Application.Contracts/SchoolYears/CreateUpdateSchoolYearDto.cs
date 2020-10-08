using System.ComponentModel.DataAnnotations;

namespace Tlu.CurriculumManager.SchoolYears
{
    public class CreateUpdateSchoolYearDto 
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Course { get; set; }
    }
}

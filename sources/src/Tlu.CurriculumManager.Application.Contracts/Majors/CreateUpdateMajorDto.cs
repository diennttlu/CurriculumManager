using System.ComponentModel.DataAnnotations;

namespace Tlu.CurriculumManager.Majors
{
    public class CreateUpdateMajorDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int FacultyId { get; set; }
    }
}

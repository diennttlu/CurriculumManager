using System.ComponentModel.DataAnnotations;

namespace Tlu.CurriculumManager.Faculties
{
    public class CreateUpdateFacultyDto
    {
        [Required]
        public string Name { get; set; }
    }
}

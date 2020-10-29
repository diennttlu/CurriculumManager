using System.ComponentModel.DataAnnotations;

namespace Tlu.CurriculumManager.Genres
{
    public class CreateUpdateGenreDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int FacultyId { get; set; }

    }
}

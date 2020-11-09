using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Genres
{
    public class GenreFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? FacultyId { get; set; }
    }
}

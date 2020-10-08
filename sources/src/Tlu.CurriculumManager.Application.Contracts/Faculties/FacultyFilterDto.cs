using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Faculties
{
    public class FacultyFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }
}

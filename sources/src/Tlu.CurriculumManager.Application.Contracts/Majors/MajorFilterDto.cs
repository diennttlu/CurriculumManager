using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Majors
{
    public class MajorFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? FacultyId { get; set; }
    }
}

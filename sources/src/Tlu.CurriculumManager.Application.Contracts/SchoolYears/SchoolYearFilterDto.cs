using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.SchoolYears
{
    public class SchoolYearFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Course { get; set; }
    }
}

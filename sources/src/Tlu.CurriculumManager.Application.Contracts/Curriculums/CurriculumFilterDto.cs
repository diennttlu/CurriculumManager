using Tlu.CurriculumManager.Enums;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Curriculums
{
    public class CurriculumFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? MajorId { get; set; }
        
        public int? SchoolYearId { get; set; }

        public ApproveStatus? ApproveStatus { get; set; }
    }
}

using Tlu.CurriculumManager.Enums;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Outlines
{
    public class OutlineFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public ApproveStatus? ApproveStatus { get; set; }

        public string SubjectName { get; set; }

        public int? SchoolYearId { get; set; }
    }
}

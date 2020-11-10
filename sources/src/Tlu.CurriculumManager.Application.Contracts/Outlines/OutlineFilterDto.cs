using Tlu.CurriculumManager.Enums;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Outlines
{
    public class OutlineFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Goal { get; set; }

        public string Assessment { get; set; }

        public string Content { get; set; }

        public ApproveStatus? ApproveStatus { get; set; }

        public int? SubjectId { get; set; }

        public int? OutlineId { get; set; }
    }
}

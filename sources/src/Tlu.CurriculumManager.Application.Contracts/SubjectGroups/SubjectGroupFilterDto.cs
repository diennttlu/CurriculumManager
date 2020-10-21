using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.SubjectGroups
{
    public class SubjectGroupFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? CurriculumId { get; set; }

        public int? ParentId { get; set; }
    }
}

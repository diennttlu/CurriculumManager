using Tlu.CurriculumManager.Enums;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Documents
{
    public class DocumentFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string LibraryCode { get; set; }

        public InLibrary? InLibrary { get; set; }

        public string Isbn { get; set; }
    }
}

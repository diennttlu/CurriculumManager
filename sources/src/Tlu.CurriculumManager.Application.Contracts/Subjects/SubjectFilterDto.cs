using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Subjects
{
    public class SubjectFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? UnitMin { get; set; }

        public int? UnitMax { get; set; }

        public string Condition { get; set; }

        public string HoursStudy { get; set; }

        public double? CoefficientMin { get; set; }

        public double? CoefficientMax { get; set; }
    }
}

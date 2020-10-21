using System.ComponentModel.DataAnnotations;

namespace Tlu.CurriculumManager.SubjectGroups
{
    public class CreateUpdateSubjectGroupDto
    {
        [Required]
        public string Name { get; set; }

        public string Note { get; set; }

        [Required]
        public int CurriculumId { get; set; }

        public int? ParentId { get; set; }

        public int? UnitTotal { get; set; }
    }
}

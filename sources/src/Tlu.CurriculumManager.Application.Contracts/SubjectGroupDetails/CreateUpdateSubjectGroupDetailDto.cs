using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tlu.CurriculumManager.SubjectGroupDetails
{
    public class CreateUpdateSubjectGroupDetailDto
    {
        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int SubjectGroupId { get; set; }

    }
}

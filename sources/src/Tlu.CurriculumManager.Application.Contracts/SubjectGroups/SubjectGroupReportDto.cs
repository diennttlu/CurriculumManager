using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.SubjectGroupDetails;
using Tlu.CurriculumManager.Subjects;

namespace Tlu.CurriculumManager.SubjectGroups
{
    public class SubjectGroupReportDto 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public int DisplayOrder { get; set; }

        public SubjectGroupDto Parent { get; set; }

        public ICollection<SubjectGroupDto> Childrens { get; set; }

        public List<SubjectGroupDetailDto> SubjectGroupDetails { get; set; }
    }
}

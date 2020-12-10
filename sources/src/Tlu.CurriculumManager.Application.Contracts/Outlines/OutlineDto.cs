using System.Collections.Generic;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.OutlineDocuments;
using Tlu.CurriculumManager.SchoolYears;
using Tlu.CurriculumManager.Subjects;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Outlines
{
    public class OutlineDto : EntityDto<int>
    {
        public string Description { get; set; }

        public string Goal { get; set; }

        public string Assessment { get; set; }

        public string Content { get; set; }

        public ApproveStatus ApproveStatus { get; set; }

        public int SubjectId { get; set; }

        public int OutlineId { get; set; }

        public SubjectDto Subject { get; set; }

        public SchoolYearDto SchoolYear { get; set; }

        public ICollection<OutlineDocumentDto> OutlineDocuments { get; set; }
    }
}

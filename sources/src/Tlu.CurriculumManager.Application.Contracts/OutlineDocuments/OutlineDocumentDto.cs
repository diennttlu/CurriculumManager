using Tlu.CurriculumManager.Documents;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.Outlines;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager.OutlineDocuments
{
    public class OutlineDocumentDto : EntityDto<int>
    {
        public int OutlineId { get; set; }

        public int DocumentId { get; set; }

        public DocumentType DocumentType { get; set; }

        public OutlineDto Outline { get; set; }

        public DocumentDto Document { get; set; }
    }
}

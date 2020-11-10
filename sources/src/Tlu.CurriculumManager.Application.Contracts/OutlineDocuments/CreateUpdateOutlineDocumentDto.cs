using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.OutlineDocuments
{
    public class CreateUpdateOutlineDocumentDto
    {
        public int OutlineId { get; set; }

        public int DocumentId { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}

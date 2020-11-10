using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.OutlineDocuments;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Documents
{
    public class DocumentDto : EntityDto<int>
    {
        public string Name { get; set; }

        public string LibraryCode { get; set; }

        public InLibrary InLibrary { get; set; }

        public string Isbn { get; set; }

        public ICollection<OutlineDocumentDto> OutlineDocuments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.Documents
{
    public class DocumentShowOnOutlineDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LibraryCode { get; set; }

        public InLibrary InLibrary { get; set; }

        public string Isbn { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}

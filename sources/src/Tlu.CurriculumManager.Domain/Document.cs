using System;
using System.Collections.Generic;
using Tlu.CurriculumManager.Enums;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Document : Entity<int>
    {
        public string Name { get; set; }

        public string LibraryCode { get; set; }

        public InLibrary InLibrary { get; set; }

        public string Isbn { get; set; }

        public virtual ICollection<OutlineDocument> OutlineDocuments { get; set; }

        public Document()
        {
            OutlineDocuments = new HashSet<OutlineDocument>();
        }
    }
}

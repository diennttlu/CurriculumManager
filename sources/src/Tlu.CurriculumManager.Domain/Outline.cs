using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Outline : Entity<int>
    {
        public string Goal { get; set; }

        public string Assessment { get; set; }

        public string Content { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Modified { get; set; }

        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ICollection<OutlineDocument> OutlineDocuments { get; set; }

        public Outline()
        {
            OutlineDocuments = new HashSet<OutlineDocument>();
        }
    }
}

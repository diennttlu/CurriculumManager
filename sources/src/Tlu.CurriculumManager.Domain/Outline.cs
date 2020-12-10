using System;
using System.Collections.Generic;
using Tlu.CurriculumManager.Enums;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class Outline : Entity<int>
    {
        public string Description { get; set; }

        public string Goal { get; set; }

        public string Assessment { get; set; }

        public string Content { get; set; }

        public ApproveStatus ApproveStatus { get; set; }

        public int SubjectId { get; set; }

        public int OutlineId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }

        public virtual ICollection<OutlineDocument> OutlineDocuments { get; set; }

        public Outline()
        {
            OutlineDocuments = new HashSet<OutlineDocument>();
        }
    }
}

using Tlu.CurriculumManager.Enums;
using Volo.Abp.Domain.Entities;

namespace Tlu.CurriculumManager
{
    public class OutlineDocument : Entity<int>
    {
        public int OutlineId { get; set; }

        public int DocumentId { get; set; }

        public DocumentType DocumentType { get; set; }

        public virtual Outline Outline { get; set; }

        public virtual Document Document { get; set; }
    }
}

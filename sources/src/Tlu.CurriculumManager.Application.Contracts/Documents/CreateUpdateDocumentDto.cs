using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.Documents
{
    public class CreateUpdateDocumentDto
    {
        public string Name { get; set; }

        public string LibraryCode { get; set; }

        public InLibrary InLibrary { get; set; }

        public string Isbn { get; set; }
    }
}

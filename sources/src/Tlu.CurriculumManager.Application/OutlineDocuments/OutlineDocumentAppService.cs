using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.OutlineDocuments
{
    public class OutlineDocumentAppService : CrudAppService<
        OutlineDocument,
        OutlineDocumentDto,
        int,
        CreateUpdateOutlineDocumentDto,
        CreateUpdateOutlineDocumentDto>, IOutlineDocumentAppService
    {
        public OutlineDocumentAppService(IRepository<OutlineDocument, int> repository) : base(repository)
        {
        }
    }
}

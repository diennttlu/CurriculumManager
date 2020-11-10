using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Documents
{
    public class DocumentAppService : CrudAppService<
        Document,
        DocumentDto,
        int,
        DocumentFilterDto,
        CreateUpdateDocumentDto,
        CreateUpdateDocumentDto>, IDocumentAppService
    {
        public DocumentAppService(IRepository<Document, int> repository) : base(repository)
        {

        }

        public List<DocumentDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Document>, List<DocumentDto>>(Repository.ToList());
        }
    }
}

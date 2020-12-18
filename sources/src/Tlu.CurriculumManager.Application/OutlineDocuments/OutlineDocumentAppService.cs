using System.Collections.Generic;
using System.Linq;
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

        public List<OutlineDocumentDto> GetListByOutlineId(int outlineId)
        {
            var outlineDocuments = Repository.WithDetails(x => x.Document).Where(x => x.Outline.Id == outlineId).ToList();
            return ObjectMapper.Map<List<OutlineDocument>, List<OutlineDocumentDto>>(outlineDocuments);
        }
    }
}

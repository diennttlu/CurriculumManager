using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.OutlineDocuments
{
    public interface IOutlineDocumentAppService : ICrudAppService<
        OutlineDocumentDto,
        int,
        CreateUpdateOutlineDocumentDto,
        CreateUpdateOutlineDocumentDto>
    {
        List<OutlineDocumentDto> GetListByOutlineId(int outlineId);
    }
}

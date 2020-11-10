using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Documents
{
    public interface IDocumentAppService : ICrudAppService<
        DocumentDto,
        int,
        DocumentFilterDto,
        CreateUpdateDocumentDto,
        CreateUpdateDocumentDto>
    {
        List<DocumentDto> GetAllSelection();
    }
}

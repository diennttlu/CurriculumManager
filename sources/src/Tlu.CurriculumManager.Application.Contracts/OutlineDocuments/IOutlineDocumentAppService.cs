using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.OutlineDocuments
{
    public interface IOutlineDocumentAppService : ICrudAppService<
        OutlineDocumentDto,
        int,
        CreateUpdateOutlineDocumentDto,
        CreateUpdateOutlineDocumentDto>
    {

    }
}

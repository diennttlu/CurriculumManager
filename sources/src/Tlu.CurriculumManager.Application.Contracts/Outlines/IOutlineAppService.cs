using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Outlines
{
    public interface IOutlineAppService : ICrudAppService<
        OutlineDto,
        int,
        OutlineFilterDto,
        CreateUpdateOutlineDto,
        CreateUpdateOutlineDto>
    {
        List<OutlineDto> GetAllSelection();
    }
}

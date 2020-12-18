using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<OutlineDetailDto> GetDetailById(int id);
    }
}

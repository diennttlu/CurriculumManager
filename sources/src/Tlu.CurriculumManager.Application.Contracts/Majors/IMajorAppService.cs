using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Majors
{
    public interface IMajorAppService : ICrudAppService<
        MajorDto,
        int,
        MajorFilterDto,
        CreateUpdateMajorDto,
        CreateUpdateMajorDto>
    {
        List<MajorDto> GetAllSelection();
    }
}

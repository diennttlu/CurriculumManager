using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.SchoolYears
{
    public interface ISchoolYearAppService : ICrudAppService<
        SchoolYearDto,
        int,
        SchoolYearFilterDto,
        CreateUpdateSchoolYearDto,
        CreateUpdateSchoolYearDto>
    {
        List<SchoolYearDto> GetAllSelection();
    }
}

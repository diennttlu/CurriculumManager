using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Teachers
{
    public interface ITeacherAppService : ICrudAppService<
        TeacherDto,
        int,
        TeacherFilterDto,
        CreateUpdateTeacherDto,
        CreateUpdateTeacherDto>
    {
        List<TeacherDto> GetAllSelection();
    }
}

using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Faculties
{
    public interface IFacultyAppService : ICrudAppService<
        FacultyDto, 
        int,
        FacultyFilterDto,
        CreateUpdateFacultyDto,
        CreateUpdateFacultyDto>
    {
        List<FacultyDto> GetAllSelection();
    }
}

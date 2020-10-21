using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.SubjectGroups
{
    public interface ISubjectGroupAppService : ICrudAppService<
        SubjectGroupDto,
        int,
        SubjectGroupFilterDto,
        CreateUpdateSubjectGroupDto,
        CreateUpdateSubjectGroupDto>
    {
        Task<List<SubjectGroupDto>> GetByCurriculumIdAsync(int curriculumId);
        List<SubjectGroupDto> GetAllSelection();
    }
}

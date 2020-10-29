using System.Collections.Generic;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Subjects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.SubjectGroupDetails
{
    public interface ISubjectGroupDetailAppService : ICrudAppService<
        SubjectGroupDetailDto,
        int,
        CreateUpdateSubjectGroupDetailDto,
        CreateUpdateSubjectGroupDetailDto>
    {
        Task<bool> IsExists(CreateUpdateSubjectGroupDetailDto input);
        Task<List<SubjectGroupDetailDto>> GetBySubjectGroupId(int subjectGroupId);
        Task<PagedResultDto<object>> GetSubjectBySubjectGroupId(SubjectGroupDetailFilterDto input);
    }
}

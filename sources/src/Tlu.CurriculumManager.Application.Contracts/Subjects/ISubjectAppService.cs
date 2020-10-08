using Tlu.CurriculumManager.Subjects;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Subjects
{
    public interface ISubjectAppService : ICrudAppService<
        SubjectDto,
        int,
        SubjectFilterDto,
        CreateUpdateSubjectDto,
        CreateUpdateSubjectDto>
    {

    }
}

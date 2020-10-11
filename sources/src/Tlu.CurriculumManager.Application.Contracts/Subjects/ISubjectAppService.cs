using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Http;

namespace Tlu.CurriculumManager.Subjects
{
    public interface ISubjectAppService : ICrudAppService<
        SubjectDto,
        int,
        SubjectFilterDto,
        CreateUpdateSubjectDto,
        CreateUpdateSubjectDto>
    {
        Task<bool> ImportFile(IFormFile file);
    }
}

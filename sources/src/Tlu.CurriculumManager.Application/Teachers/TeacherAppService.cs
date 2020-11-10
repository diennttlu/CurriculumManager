using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Teachers
{
    public class TeacherAppService : CrudAppService<
        Teacher,
        TeacherDto,
        int,
        TeacherFilterDto,
        CreateUpdateTeacherDto,
        CreateUpdateTeacherDto>, ITeacherAppService
    {
        public TeacherAppService(IRepository<Teacher, int> repository) : base(repository)
        {

        }

        public List<TeacherDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Teacher>, List<TeacherDto>>(Repository.ToList());
        }
    }
}

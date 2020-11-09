using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Curriculums;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.SchoolYears
{
    public class SchoolYearAppService : CrudAppService<
        SchoolYear,
        SchoolYearDto,
        int,
        SchoolYearFilterDto,
        CreateUpdateSchoolYearDto,
        CreateUpdateSchoolYearDto>, ISchoolYearAppService
    {
        public SchoolYearAppService(IRepository<SchoolYear, int> repository) : base(repository)
        {
        }

        public List<SchoolYearDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<SchoolYear>, List<SchoolYearDto>>(Repository.ToList());
        }

        public override Task<SchoolYearDto> GetAsync(int id)
        {
            var query = Repository.WithDetails(x => x.Curriculums).AsQueryable();
            var schoolYear = query.Where(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(ObjectMapper.Map<SchoolYear, SchoolYearDto>(schoolYear));
        }
    }
}

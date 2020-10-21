using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Curriculums
{
    public class CurriculumAppService : CrudAppService<
        Curriculum,
        CurriculumDto,
        int,
        CurriculumFilterDto,
        CreateUpdateCurriculumDto,
        CreateUpdateCurriculumDto>, ICurriculumAppService
    {
        public CurriculumAppService(IRepository<Curriculum, int> repository) 
            : base(repository)
        {

        }

        public List<CurriculumDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Curriculum>, List<CurriculumDto>>(Repository.WithDetails(s => s.SchoolYear).ToList());
        }

        public override Task<PagedResultDto<CurriculumDto>> GetListAsync(CurriculumFilterDto input)
        {
            var query = Repository.WithDetails(s => s.Major, s => s.SchoolYear).AsQueryable();
            
            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(s => s.Name.Contains(input.Name));

            if (input.MajorId.HasValue)
                query = query.Where(s => s.MajorId == input.MajorId);

            if (input.SchoolYearId.HasValue)
                query = query.Where(s => s.SchoolYearId == input.SchoolYearId);

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<CurriculumDto>(count, ObjectMapper.Map<List<Curriculum>, List<CurriculumDto>>(items));
            return Task.FromResult(result);
        }
    }
}

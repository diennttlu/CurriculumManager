using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Faculties
{
    public class FacultyAppService : CrudAppService<
        Faculty,
        FacultyDto,
        int,
        FacultyFilterDto,
        CreateUpdateFacultyDto,
        CreateUpdateFacultyDto>, IFacultyAppService
    {
        public FacultyAppService(IRepository<Faculty, int> repository) : base(repository)
        {
            
        }

        public List<FacultyDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Faculty>, List<FacultyDto>>(Repository.ToList());
        }

        public override Task<PagedResultDto<FacultyDto>> GetListAsync(FacultyFilterDto input)
        {
            var query = Repository.AsQueryable();
            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(s => s.Name.Contains(input.Name));

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<FacultyDto>(count, ObjectMapper.Map<List<Faculty>, List<FacultyDto>>(items));
            return Task.FromResult(result);
        }

    }
}

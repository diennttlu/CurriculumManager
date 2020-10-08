using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Majors
{
    public class MajorAppService : CrudAppService<
        Major,
        MajorDto,
        int,
        MajorFilterDto,
        CreateUpdateMajorDto,
        CreateUpdateMajorDto>, IMajorAppService
    {
        public MajorAppService(IRepository<Major, int> repository) : base(repository)
        {
        }

        public List<MajorDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Major>, List<MajorDto>>(Repository.ToList());
        }

        public override Task<PagedResultDto<MajorDto>> GetListAsync(MajorFilterDto input)
        {

            var query = Repository.WithDetails(s => s.Faculty).AsQueryable();
            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(s => s.Name.Contains(input.Name));

            if (input.FacultyId.HasValue)
                query = query.Where(s => s.FacultyId == input.FacultyId);

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<MajorDto>(count, ObjectMapper.Map<List<Major>, List<MajorDto>>(items));
            return Task.FromResult(result);
        }
    }
}

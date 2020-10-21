using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.SubjectGroups;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.SubjectGroups
{
    public class SubjectGroupAppService : CrudAppService<
        SubjectGroup,
        SubjectGroupDto,
        int,
        SubjectGroupFilterDto,
        CreateUpdateSubjectGroupDto,
        CreateUpdateSubjectGroupDto>, ISubjectGroupAppService
    {
        public SubjectGroupAppService(IRepository<SubjectGroup, int> repository) : base(repository)
        {

        }

        public List<SubjectGroupDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<SubjectGroup>, List<SubjectGroupDto>>(Repository.ToList());
        }

        public Task<List<SubjectGroupDto>> GetByCurriculumIdAsync(int curriculumId)
        {
            var subjectGroups = Repository.Where(x => x.CurriculumId == curriculumId).ToList();
            return Task.FromResult(ObjectMapper.Map<List<SubjectGroup>, List<SubjectGroupDto>>(subjectGroups));
        }

        public override Task<PagedResultDto<SubjectGroupDto>> GetListAsync(SubjectGroupFilterDto input)
        {
            var query = Repository.WithDetails(s => s.Curriculum, s => s.Parent, s => s.Curriculum.SchoolYear).AsQueryable();

            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(s => s.Name.Contains(input.Name));

            if (input.CurriculumId.HasValue)
                query = query.Where(s => s.CurriculumId == input.CurriculumId);

            if (input.ParentId.HasValue)
                query = query.Where(s => s.ParentId.HasValue && s.ParentId == input.ParentId);

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<SubjectGroupDto>(count, ObjectMapper.Map<List<SubjectGroup>, List<SubjectGroupDto>>(items));
            return Task.FromResult(result);
        }
    }
}

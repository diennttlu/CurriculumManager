using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Subjects
{
    public class SubjectAppService : CrudAppService<
        Subject,
        SubjectDto,
        int,
        SubjectFilterDto,
        CreateUpdateSubjectDto,
        CreateUpdateSubjectDto>, ISubjectAppService
    {
        public SubjectAppService(IRepository<Subject, int> repository) : base(repository)
        {

        }

        public override Task<PagedResultDto<SubjectDto>> GetListAsync(SubjectFilterDto input)
        {
            var query = Repository.AsQueryable();
            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.Code))
                query = query.Where(s => s.Code.Contains(input.Code));

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(s => s.Name.Contains(input.Name));

            if (input.UnitMin.HasValue)
                query = query.Where(s => s.Unit >= input.UnitMin);

            if (input.UnitMax.HasValue)
                query = query.Where(s => s.Unit <= input.UnitMax);

            if (!string.IsNullOrEmpty(input.Condition))
                query = query.Where(s => s.Condition.Contains(input.Condition));

            if (!string.IsNullOrEmpty(input.HoursStudy))
                query = query.Where(s => s.HoursStudy.Contains(input.HoursStudy));

            if (input.CoefficientMin.HasValue)
                query = query.Where(s => s.Coefficient >= input.CoefficientMin);

            if (input.CoefficientMax.HasValue)
                query = query.Where(s => s.Coefficient <= input.CoefficientMax);

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<SubjectDto>(count, ObjectMapper.Map<List<Subject>, List<SubjectDto>>(items));
            return Task.FromResult(result);
        }
    }
}

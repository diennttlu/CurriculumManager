using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Subjects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.SubjectGroupDetails
{
    public class SubjectGroupDetailAppService : CrudAppService<
        SubjectGroupDetail, 
        SubjectGroupDetailDto, 
        int,
        CreateUpdateSubjectGroupDetailDto,
        CreateUpdateSubjectGroupDetailDto>,
        ISubjectGroupDetailAppService
    {
        public SubjectGroupDetailAppService(IRepository<SubjectGroupDetail, int> repository) : base(repository)
        {
        }

        public Task<List<SubjectGroupDetailDto>> GetBySubjectGroupId(int subjectGroupId)
        {
            var subjectGroupDetails = Repository
                .WithDetails(x => x.Subject)
                .Where(x => x.SubjectGroupId == subjectGroupId)
                .ToList();

            return Task.FromResult(ObjectMapper.Map<List<SubjectGroupDetail>, List<SubjectGroupDetailDto>>(subjectGroupDetails));
        }

        public Task<PagedResultDto<object>> GetSubjectBySubjectGroupId(SubjectGroupDetailFilterDto input)
        {
            var subjects = Repository
                .WithDetails(x => x.Subject)
                .Where(x => x.SubjectGroupId == input.SubjectGroupId)
                .Select(x => new 
                { 
                    Id = x.Subject.Id,
                    Code = x.Subject.Code,
                    Name = x.Subject.Name,
                    Unit = x.Subject.Unit,
                    Condition = x.Subject.Condition,
                    HoursStudy = x.Subject.HoursStudy,
                    Coefficient = x.Subject.Coefficient,
                    SubjectGroupDetailId = x.Id
                }).OrderBy(x => x.Id).ToList();
            var result = new PagedResultDto<object>(subjects.Count, subjects);
            return Task.FromResult(result);
        }


        public Task<bool> IsExists(CreateUpdateSubjectGroupDetailDto input)
        {
            var isExists = Repository.Any(x => x.SubjectGroupId == input.SubjectGroupId && x.SubjectId == input.SubjectId);
            return Task.FromResult(isExists);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Subjects;
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

        public Task<List<SubjectDto>> GetSubjectBySubjectGroupId(int subjectGroupId)
        {
            var subjects = Repository
                .WithDetails(x => x.Subject)
                .Where(x => x.SubjectGroupId == subjectGroupId)
                .Select(x => x.Subject).ToList();

            return Task.FromResult(ObjectMapper.Map<List<Subject>, List<SubjectDto>>(subjects));
        }
    }
}

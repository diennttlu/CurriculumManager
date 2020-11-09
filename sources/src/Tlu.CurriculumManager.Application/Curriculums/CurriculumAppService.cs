using Org.BouncyCastle.Math.EC.Rfc7748;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.SubjectGroups;
using Tlu.CurriculumManager.Subjects;
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
        private readonly IRepository<SubjectGroup, int> _subjectGroupsRepository;
        private readonly IRepository<SubjectGroupDetail, int> _subjectGroupDetailRepository;

        public CurriculumAppService(
            IRepository<Curriculum, int> repository,
            IRepository<SubjectGroup, int> subjectGroupsRepository,
            IRepository<SubjectGroupDetail, int> subjectGroupDetailRepository
            ) 
            : base(repository)
        {
            _subjectGroupsRepository = subjectGroupsRepository;
            _subjectGroupDetailRepository = subjectGroupDetailRepository;
        }

        public List<CurriculumDto> GetAllBySchoolYearId(int schoolYearId)
        {
            var curriculums = Repository.Where(x => x.SchoolYearId == schoolYearId).ToList();

            return ObjectMapper.Map<List<Curriculum>, List<CurriculumDto>>(curriculums.OrderByDescending(x => x.Id).ToList());
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

        public Task<List<SubjectDto>> GetSubjectByCurriculumId(int curriculumId)
        {
            var subjectGroupsId = _subjectGroupsRepository
                .WithDetails(x => x.SubjectGroupDetails)
                .Where(x => x.CurriculumId == curriculumId).Select(x => x.Id).ToList();
            var query = _subjectGroupDetailRepository.WithDetails(x => x.Subject).AsQueryable();
            var subjects = query.Where(x => subjectGroupsId.Contains(x.SubjectGroupId)).Select(x => x.Subject).ToList();

            return Task.FromResult(ObjectMapper.Map<List<Subject>, List<SubjectDto>>(subjects));
        }

        public Task<List<CurriculumExportDto>> ExportPDF(int curriculumId)
        {
            var exports = new List<CurriculumExportDto>();
            var subjectGroups = _subjectGroupsRepository
                .WithDetails(x => x.SubjectGroupDetails)
                .Where(x => x.CurriculumId == curriculumId).ToList().OrderBy(x => x.DisplayOrder);
            foreach (var item in subjectGroups)
            {
                var query = _subjectGroupDetailRepository.WithDetails(x => x.Subject).AsQueryable();
                var subjects = query.Where(x => x.SubjectGroupId == item.Id).Select(x => x.Subject).ToList();
                var subjectDtos = ObjectMapper.Map<List<Subject>, List<SubjectDto>>(subjects);
                exports.Add(new CurriculumExportDto() 
                {
                    SubjectGroup = ObjectMapper.Map<SubjectGroup, SubjectGroupDto>(item),
                    Subjects = subjectDtos
                });
            }

            return Task.FromResult(exports);
        }
    }
}

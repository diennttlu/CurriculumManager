using Org.BouncyCastle.Math.EC.Rfc7748;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.SubjectGroupDetails;
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
        private readonly IRepository<SchoolYear, int> _schoolYearRepository;

        public CurriculumAppService(
            IRepository<Curriculum, int> repository,
            IRepository<SubjectGroup, int> subjectGroupsRepository,
            IRepository<SubjectGroupDetail, int> subjectGroupDetailRepository,
            IRepository<SchoolYear, int> schoolYearRepository
            ) 
            : base(repository)
        {
            _subjectGroupsRepository = subjectGroupsRepository;
            _subjectGroupDetailRepository = subjectGroupDetailRepository;
            _schoolYearRepository = schoolYearRepository;
        }

        public override Task<CurriculumDto> GetAsync(int id)
        {
            var curriculum = Repository.WithDetails(x => x.SchoolYear).Where(x => x.Id == id).FirstOrDefault();

            return Task.FromResult(ObjectMapper.Map<Curriculum, CurriculumDto>(curriculum));
        }

        public List<CurriculumDto> GetAllBySchoolYearId(int schoolYearId)
        {
            var curriculums = Repository
                .WithDetails(x => x.SchoolYear)
                .Where(x => x.SchoolYearId == schoolYearId && x.ApproveStatus == ApproveStatus.Approved)
                .ToList();

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

        public Task<List<SubjectGroupReportDto>> GetSubjectGroupsByCurriculumId(int curriculumId)
        {
            var subjectGroupDetails = _subjectGroupDetailRepository.WithDetails(x => x.Subject).AsQueryable();
            var subjectGroups = _subjectGroupsRepository
                .WithDetails(x => x.SubjectGroupDetails)
                .Where(x => x.CurriculumId == curriculumId).Select(x => new SubjectGroupReportDto() 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Note = x.Note,
                    DisplayOrder = x.DisplayOrder,
                    Parent = ObjectMapper.Map<SubjectGroup, SubjectGroupDto>(x.Parent),
                    Childrens = ObjectMapper.Map<ICollection<SubjectGroup>, ICollection<SubjectGroupDto>>(x.Childrens)
                }).ToList();
            foreach (var item in subjectGroups)
            {
                var subjectGroupDetail = subjectGroupDetails.Where(x => x.SubjectGroupId == item.Id).ToList();
                item.SubjectGroupDetails = ObjectMapper.Map<List<SubjectGroupDetail>, List<SubjectGroupDetailDto>>(subjectGroupDetail);
                if (item.Childrens.Count > 0)
                {
                    foreach(var child in item.Childrens)
                    {
                        var childSubjectGroupDetail = subjectGroupDetails.Where(x => x.SubjectGroupId == child.Id).ToList();
                        child.SubjectGroupDetails = ObjectMapper.Map<List<SubjectGroupDetail>, List<SubjectGroupDetailDto>>(childSubjectGroupDetail);
                        child.Childrens = ObjectMapper
                            .Map<ICollection<SubjectGroup>, ICollection<SubjectGroupDto>>(_subjectGroupsRepository
                            .Where(x => x.ParentId == child.Id).ToList());
                        if (child.Childrens.Count > 0)
                        {
                            foreach (var childC in child.Childrens)
                            {
                                var childCSubjectGroupDetail = subjectGroupDetails.Where(x => x.SubjectGroupId == childC.Id).ToList();
                                childC.SubjectGroupDetails = ObjectMapper.Map<List<SubjectGroupDetail>, List<SubjectGroupDetailDto>>(childSubjectGroupDetail);
                            }
                        }
                    }
                }
            }
            return Task.FromResult(subjectGroups.OrderBy(x => x.Id).ToList());
        }

        public List<CurriculumDto> GetAllByLastSchoolYear()
        {
            var lastSchoolYear = _schoolYearRepository.OrderByDescending(x => x.Id).FirstOrDefault();
            var curriculums = Repository
                .WithDetails(x => x.SchoolYear)
                .Where(x => x.SchoolYearId == lastSchoolYear.Id)
                .ToList();
            return ObjectMapper.Map<List<Curriculum>, List<CurriculumDto>>(curriculums.OrderByDescending(x => x.Id).ToList());
        }

        public List<SubjectDto> GetSubjectsBySchoolYearId(int schoolYearId)
        {
            var subjectGroups = Repository.WithDetails(x => x.SubjectGroups)
                .Where(x => x.SchoolYearId == schoolYearId)
                .SelectMany(x => x.SubjectGroups)
                .ToList();
            var subjectGroupIds = subjectGroups.Select(x => x.Id).ToList();
            var subjects = _subjectGroupDetailRepository
                .WithDetails(x => x.Subject)
                .Where(x => subjectGroupIds.Contains(x.SubjectGroupId))
                .Select(x => x.Subject)
                .Distinct().ToList();
            return ObjectMapper.Map<List<Subject>, List<SubjectDto>>(subjects);
        }
    }
}

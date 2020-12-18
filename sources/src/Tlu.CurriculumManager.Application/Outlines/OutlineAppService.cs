using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Documents;
using Tlu.CurriculumManager.SchoolYears;
using Tlu.CurriculumManager.Subjects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Outlines
{
    public class OutlineAppService : CrudAppService<
        Outline,
        OutlineDto,
        int,
        OutlineFilterDto,
        CreateUpdateOutlineDto,
        CreateUpdateOutlineDto>, IOutlineAppService
    {
        private readonly IRepository<OutlineDocument, int> _outlineDocumentRepository;

        public OutlineAppService(
            IRepository<Outline, int> repository,
            IRepository<OutlineDocument, int> outlineDocumentRepository
        ) : base(repository)
        {
            _outlineDocumentRepository = outlineDocumentRepository;
        }

        public List<OutlineDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Outline>, List<OutlineDto>>(Repository.ToList());
        }

        public Task<OutlineDetailDto> GetDetailById(int id)
        {
            var outline = Repository.WithDetails(x => x.Subject, x => x.SchoolYear).Where(x => x.Id == id).FirstOrDefault();
            var documents = _outlineDocumentRepository
                .WithDetails(x => x.Document)
                .Where(x => x.OutlineId == outline.Id)
                .Select(x => new DocumentShowOnOutlineDetail 
                {
                    Id = x.Document.Id,
                    Name = x.Document.Name,
                    LibraryCode = x.Document.LibraryCode,
                    Isbn = x.Document.Isbn,
                    DocumentType = x.DocumentType
                }).ToList();
            return Task.FromResult(new OutlineDetailDto() 
            {
                Id = outline.Id,
                Description = outline.Description,
                Goal = outline.Goal,
                Assessment = outline.Assessment,
                Content = outline.Content,
                SubjectId = outline.SubjectId,
                SchoolYearId = outline.SchoolYearId,
                Subject = ObjectMapper.Map<Subject, SubjectDto>(outline.Subject),
                SchoolYear = ObjectMapper.Map<SchoolYear, SchoolYearDto>(outline.SchoolYear),
                Documents = documents
            });
        }

        public override Task<PagedResultDto<OutlineDto>> GetListAsync(OutlineFilterDto input)
        {
            var query = Repository.WithDetails(s => s.Subject, s => s.SchoolYear).AsQueryable();

            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.SubjectName))
                query = query.Where(s => s.Subject.Name.Contains(input.SubjectName));

            if (input.ApproveStatus.HasValue)
                query = query.Where(s => s.ApproveStatus == input.ApproveStatus);

            if (input.SchoolYearId.HasValue)
                query = query.Where(s => s.SchoolYearId == input.SchoolYearId);

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<OutlineDto>(count, ObjectMapper.Map<List<Outline>, List<OutlineDto>>(items));
            return Task.FromResult(result);
        }


    }
}

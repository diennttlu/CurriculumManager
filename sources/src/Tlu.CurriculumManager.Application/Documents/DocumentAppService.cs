using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Documents
{
    public class DocumentAppService : CrudAppService<
        Document,
        DocumentDto,
        int,
        DocumentFilterDto,
        CreateUpdateDocumentDto,
        CreateUpdateDocumentDto>, IDocumentAppService
    {
        public DocumentAppService(IRepository<Document, int> repository) : base(repository)
        {

        }

        public override Task<PagedResultDto<DocumentDto>> GetListAsync(DocumentFilterDto input)
        {
            var query = Repository.AsQueryable();
            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(s => s.Name.Contains(input.Name));

            if (!string.IsNullOrEmpty(input.LibraryCode))
                query = query.Where(s => s.LibraryCode.Contains(input.LibraryCode));

            if (input.InLibrary.HasValue)
                query = query.Where(s => s.InLibrary == input.InLibrary);

            if (!string.IsNullOrEmpty(input.Isbn))
                query = query.Where(s => s.Isbn.Contains(input.Isbn));

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<DocumentDto>(count, ObjectMapper.Map<List<Document>, List<DocumentDto>>(items));
            return Task.FromResult(result);
        }

        public List<DocumentDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Document>, List<DocumentDto>>(Repository.ToList());
        }
    }
}

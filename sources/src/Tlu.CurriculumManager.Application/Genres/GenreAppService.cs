using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Genres
{
    public class GenreAppService : CrudAppService<
        Genre,
        GenreDto,
        int,
        GenreFilterDto,
        CreateUpdateGenreDto,
        CreateUpdateGenreDto>, IGenreAppService
    {
        public GenreAppService(IRepository<Genre, int> repository) : base(repository)
        {
        }

        public List<GenreDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Genre>, List<GenreDto>>(Repository.ToList());
        }

        public override Task<PagedResultDto<GenreDto>> GetListAsync(GenreFilterDto input)
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
            var result = new PagedResultDto<GenreDto>(count, ObjectMapper.Map<List<Genre>, List<GenreDto>>(items));
            return Task.FromResult(result);
        }
    }
}

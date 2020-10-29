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
    }
}

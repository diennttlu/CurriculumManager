using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Genres
{
    public interface IGenreAppService : ICrudAppService<
        GenreDto,
        int,
        GenreFilterDto,
        CreateUpdateGenreDto,
        CreateUpdateGenreDto>
    {
        List<GenreDto> GetAllSelection();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Genres;
using Tlu.CurriculumManager.Users;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Teachers
{
    public class TeacherAppService : CrudAppService<
        Teacher,
        TeacherDto,
        int,
        TeacherFilterDto,
        CreateUpdateTeacherDto,
        CreateUpdateTeacherDto>, ITeacherAppService
    {
        private readonly IRepository<AppUser, Guid> _userRepository;
        public TeacherAppService(
            IRepository<Teacher, int> repository, 
            IRepository<AppUser, Guid> userRepository)
            : base(repository)
        {
            _userRepository = userRepository;
        }

        public override Task<PagedResultDto<TeacherDto>> GetListAsync(TeacherFilterDto input)
        {
            var teachers = Repository.WithDetails(x => x.Genre).AsQueryable();
            var query = teachers
                .Join(_userRepository,
                t => t.UserId,
                u => u.Id,
                (t, u) => new TeacherDto() 
                {
                    Id = t.Id,
                    Name = $"{u.Surname} {u.Name}",
                    Genre = ObjectMapper.Map<Genre, GenreDto>(t.Genre),
                    Position = t.Position
                });

            //if (input.Id.HasValue)
            //    query = query.Where(x => x.Id == input.Id);

            //if (!string.IsNullOrEmpty(input.Name))
            //    query = query.Where(x => x.Name.Contains(input.Name));

            //if (input.GenreId.HasValue)
            //    query = query.Where(x => x.GenreId == input.GenreId);

            //if (input.Position.HasValue)
            //    query = query.Where(x => x.Position == input.Position);

            var count = query.Count();

            var items = query.ToList();
            var result = new PagedResultDto<TeacherDto>(count, items);
            return Task.FromResult(result);
        }

        public List<TeacherDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Teacher>, List<TeacherDto>>(Repository.ToList());
        }
    }
}

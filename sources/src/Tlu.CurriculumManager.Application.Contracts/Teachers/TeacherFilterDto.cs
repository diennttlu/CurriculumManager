using System;
using Tlu.CurriculumManager.Enums;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Teachers
{
    public class TeacherFilterDto : PagedAndSortedResultRequestDto
    {
        public int? Id { get; set; }

        public Guid? UserId { get; set; }

        public int GenreId { get; set; }

        public Position? Position { get; set; }
    }
}

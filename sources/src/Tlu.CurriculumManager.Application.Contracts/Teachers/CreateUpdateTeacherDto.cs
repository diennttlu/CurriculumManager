using System;
using Tlu.CurriculumManager.Enums;

namespace Tlu.CurriculumManager.Teachers
{
    public class CreateUpdateTeacherDto
    {
        public Guid UserId { get; set; }

        public int GenreId { get; set; }

        public Position Position { get; set; }
    }
}

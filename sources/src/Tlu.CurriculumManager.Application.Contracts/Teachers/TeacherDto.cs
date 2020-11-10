using System;
using System.Collections.Generic;
using Tlu.CurriculumManager.Enums;
using Tlu.CurriculumManager.Genres;
using Tlu.CurriculumManager.TeacherSubjects;
using Volo.Abp.Application.Dtos;

namespace Tlu.CurriculumManager.Teachers
{
    public class TeacherDto : EntityDto<int>
    {
        public Guid UserId { get; set; }

        public int GenreId { get; set; }

        public Position Position { get; set; }

        public GenreDto Genre { get; set; }

        public ICollection<TeacherSubjectDto> TeacherSubjects { get; set; }
    }
}

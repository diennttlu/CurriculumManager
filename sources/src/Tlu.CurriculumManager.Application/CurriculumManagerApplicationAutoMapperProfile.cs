using AutoMapper;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Majors;
using Tlu.CurriculumManager.SchoolYears;
using Tlu.CurriculumManager.SubjectGroups;
using Tlu.CurriculumManager.Subjects;

namespace Tlu.CurriculumManager
{
    public class CurriculumManagerApplicationAutoMapperProfile : Profile
    {
        public CurriculumManagerApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Subject, SubjectDto>();
            CreateMap<CreateUpdateSubjectDto, Subject>();

            CreateMap<Faculty, FacultyDto>();
            CreateMap<CreateUpdateFacultyDto, Faculty>();

            CreateMap<Major, MajorDto>();
            CreateMap<CreateUpdateMajorDto, Major>();

            CreateMap<SchoolYear, SchoolYearDto>();
            CreateMap<CreateUpdateSchoolYearDto, SchoolYear>();
        }
    }
}

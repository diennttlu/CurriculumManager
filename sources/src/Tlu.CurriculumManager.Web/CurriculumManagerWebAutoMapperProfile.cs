using AutoMapper;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.Documents;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Genres;
using Tlu.CurriculumManager.Majors;
using Tlu.CurriculumManager.Outlines;
using Tlu.CurriculumManager.SchoolYears;
using Tlu.CurriculumManager.Subjects;
using Tlu.CurriculumManager.Teachers;
using static Tlu.CurriculumManager.Web.Pages.Curriculums.CreateModalModel;
using static Tlu.CurriculumManager.Web.Pages.Genres.CreateModalModel;
using static Tlu.CurriculumManager.Web.Pages.Majors.CreateModalModel;
using static Tlu.CurriculumManager.Web.Pages.Teachers.CreateModalModel;

namespace Tlu.CurriculumManager.Web
{
    public class CurriculumManagerWebAutoMapperProfile : Profile
    {
        public CurriculumManagerWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<SubjectDto, CreateUpdateSubjectDto>();
            CreateMap<FacultyDto, CreateUpdateFacultyDto>();
            CreateMap<SchoolYearDto, CreateUpdateSchoolYearDto>();

            CreateMap<MajorFormModel, CreateUpdateMajorDto>();
            CreateMap<MajorDto, MajorFormModel> ();

            CreateMap<CurriculumFormModel, CreateUpdateCurriculumDto>();
            CreateMap<CurriculumDto, CurriculumFormModel>();

            CreateMap<GenreFormModel, CreateUpdateGenreDto>();
            CreateMap<GenreDto, GenreFormModel>();

            CreateMap<DocumentDto, CreateUpdateDocumentDto>();
            CreateMap<OutlineDto, CreateUpdateOutlineDto>();

            CreateMap<TeacherFormModel, CreateUpdateTeacherDto>();
            CreateMap<TeacherDto, TeacherFormModel>();
        }
    }
}

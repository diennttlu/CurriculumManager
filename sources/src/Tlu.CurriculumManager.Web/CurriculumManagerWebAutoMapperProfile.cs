﻿using AutoMapper;
using Tlu.CurriculumManager.Curriculums;
using Tlu.CurriculumManager.Faculties;
using Tlu.CurriculumManager.Majors;
using Tlu.CurriculumManager.SchoolYears;
using Tlu.CurriculumManager.SubjectGroups;
using Tlu.CurriculumManager.Subjects;
using static Tlu.CurriculumManager.Web.Pages.Curriculums.CreateModalModel;
using static Tlu.CurriculumManager.Web.Pages.Majors.CreateModalModel;
using static Tlu.CurriculumManager.Web.Pages.SubjectGroups.CreateModalModel;

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

            CreateMap<SubjectGroupFormModel, CreateUpdateSubjectGroupDto>();
            CreateMap<SubjectGroupDto, SubjectGroupFormModel>();
        }
    }
}

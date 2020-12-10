using System.Collections.Generic;
using System.Threading.Tasks;
using Tlu.CurriculumManager.SubjectGroups;
using Tlu.CurriculumManager.Subjects;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager.Curriculums
{
    public interface ICurriculumAppService : ICrudAppService<
        CurriculumDto,
        int,
        CurriculumFilterDto,
        CreateUpdateCurriculumDto,
        CreateUpdateCurriculumDto>
    {
        List<CurriculumDto> GetAllSelection();
        List<CurriculumDto> GetAllBySchoolYearId(int schoolYearId);

        List<CurriculumDto> GetAllByLastSchoolYear();

        Task<List<SubjectGroupReportDto>> GetSubjectGroupsByCurriculumId(int curriculumId);

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<List<SubjectDto>> GetSubjectByCurriculumId(int curriculumId);

        Task<List<CurriculumExportDto>> ExportPDF(int curriculumId);
    }
}

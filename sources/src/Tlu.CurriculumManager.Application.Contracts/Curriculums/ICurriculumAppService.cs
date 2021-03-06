﻿using System.Collections.Generic;
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
    }
}

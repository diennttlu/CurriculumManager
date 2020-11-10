using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Outlines
{
    public class OutlineAppService : CrudAppService<
        Outline,
        OutlineDto,
        int,
        OutlineFilterDto,
        CreateUpdateOutlineDto,
        CreateUpdateOutlineDto>, IOutlineAppService
    {
        public OutlineAppService(IRepository<Outline, int> repository) : base(repository)
        {
        }

        public List<OutlineDto> GetAllSelection()
        {
            return ObjectMapper.Map<List<Outline>, List<OutlineDto>>(Repository.ToList());
        }
    }
}

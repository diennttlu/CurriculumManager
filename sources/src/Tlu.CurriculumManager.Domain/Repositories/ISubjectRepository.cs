using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Repositories
{
    public interface ISubjectRepository : IRepository<Subject, int>
    {
        Task BulkInsertAsync(List<Subject> subjects);
    }
}

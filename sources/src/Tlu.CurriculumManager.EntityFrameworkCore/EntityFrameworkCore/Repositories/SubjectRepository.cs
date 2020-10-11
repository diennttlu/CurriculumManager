using EFCore.BulkExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Tlu.CurriculumManager.EntityFrameworkCore.Repositories
{
    public class SubjectRepository :
        EfCoreRepository<CurriculumManagerDbContext, Subject, int>,
        ISubjectRepository
    {
        private readonly IDbContextProvider<CurriculumManagerDbContext> _dbContextProvider;

        public SubjectRepository(IDbContextProvider<CurriculumManagerDbContext> dbContextProvider)
            :base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task BulkInsertAsync(List<Subject> subjects)
        {
            await _dbContextProvider.GetDbContext().BulkInsertAsync(subjects);
        }
    }
}

using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Tlu.CurriculumManager.Data
{
    /* This is used if database provider does't define
     * ICurriculumManagerDbSchemaMigrator implementation.
     */
    public class NullCurriculumManagerDbSchemaMigrator : ICurriculumManagerDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
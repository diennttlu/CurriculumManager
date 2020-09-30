using System.Threading.Tasks;

namespace Tlu.CurriculumManager.Data
{
    public interface ICurriculumManagerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}

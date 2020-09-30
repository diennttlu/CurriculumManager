using Tlu.CurriculumManager.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Tlu.CurriculumManager.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CurriculumManagerEntityFrameworkCoreDbMigrationsModule),
        typeof(CurriculumManagerApplicationContractsModule)
        )]
    public class CurriculumManagerDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}

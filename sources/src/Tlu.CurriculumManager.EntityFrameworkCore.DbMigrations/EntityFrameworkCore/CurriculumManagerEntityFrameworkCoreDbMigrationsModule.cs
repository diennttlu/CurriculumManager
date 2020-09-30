using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Tlu.CurriculumManager.EntityFrameworkCore
{
    [DependsOn(
        typeof(CurriculumManagerEntityFrameworkCoreModule)
        )]
    public class CurriculumManagerEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CurriculumManagerMigrationsDbContext>();
        }
    }
}

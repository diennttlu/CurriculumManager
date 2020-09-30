using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tlu.CurriculumManager.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class CurriculumManagerMigrationsDbContextFactory : IDesignTimeDbContextFactory<CurriculumManagerMigrationsDbContext>
    {
        public CurriculumManagerMigrationsDbContext CreateDbContext(string[] args)
        {
            CurriculumManagerEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CurriculumManagerMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new CurriculumManagerMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Tlu.CurriculumManager.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}

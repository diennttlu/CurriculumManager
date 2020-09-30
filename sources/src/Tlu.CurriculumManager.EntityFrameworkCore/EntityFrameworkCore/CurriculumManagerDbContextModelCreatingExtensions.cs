using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Tlu.CurriculumManager.EntityFrameworkCore
{
    public static class CurriculumManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureCurriculumManager(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(CurriculumManagerConsts.DbTablePrefix + "YourEntities", CurriculumManagerConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
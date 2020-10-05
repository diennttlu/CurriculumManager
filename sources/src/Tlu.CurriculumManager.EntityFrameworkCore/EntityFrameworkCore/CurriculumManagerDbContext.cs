using Microsoft.EntityFrameworkCore;
using Tlu.CurriculumManager.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Tlu.CurriculumManager.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See CurriculumManagerMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class CurriculumManagerDbContext : AbpDbContext<CurriculumManagerDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        public DbSet<SchoolYear> SchoolYears { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Major> Majors { get; set; }

        public DbSet<Curriculum> Curriculums { get; set; }

        public DbSet<CurriculumDetail> CurriculumDetails { get; set; }
        
        public DbSet<KnowledgeGroup> KnowledgeGroups { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectGroup> KnowledgeGroupDetails { get; set; }

        public DbSet<Outline> Outlines { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<OutlineDocument> OutlineDocuments { get;set; }

        public DbSet<UserSubject> UserSubjects { get; set; }


        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside CurriculumManagerDbContextModelCreatingExtensions.ConfigureCurriculumManager
         */

        public CurriculumManagerDbContext(DbContextOptions<CurriculumManagerDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the CurriculumManagerEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureCurriculumManager method */

            builder.ConfigureCurriculumManager();
        }
    }
}

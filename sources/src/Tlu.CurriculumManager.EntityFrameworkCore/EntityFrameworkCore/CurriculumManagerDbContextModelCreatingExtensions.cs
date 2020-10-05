using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Tlu.CurriculumManager.EntityFrameworkCore
{
    public static class CurriculumManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureCurriculumManager(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Faculty>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Faculties", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired().HasMaxLength(128);
                e.HasMany(x => x.Majors).WithOne(x => x.Faculty).HasForeignKey(x => x.FacultyId);
            });

            builder.Entity<Major>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Majors", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired().HasMaxLength(128);
                e.HasMany(x => x.Curriculums).WithOne(x => x.Major).HasForeignKey(x => x.MajorId);
            });

            builder.Entity<SchoolYear>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "SchoolYears", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired().HasMaxLength(128);
                e.Property(x => x.Course).IsRequired().HasMaxLength(4);
                e.HasMany(x => x.Curriculums).WithOne(x => x.SchoolYear).HasForeignKey(x => x.SchoolYearId);
            });

            builder.Entity<Curriculum>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Curriculums", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired().HasMaxLength(512);
                e.HasMany(x => x.CurriculumDetails).WithOne(x => x.Curriculum).HasForeignKey(x => x.CurriculumId);
            });

            builder.Entity<KnowledgeGroup>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "KnowledgeGroups", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired().HasMaxLength(1024);
                e.Property(x => x.DisplayOrder).HasMaxLength(2);
                e.HasMany(x => x.CurriculumDetails).WithOne(x => x.KnowledgeGroup).HasForeignKey(x => x.KnowledgeGroupId);
            });

            builder.Entity<CurriculumDetail>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "CurriculumDetails", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Note).HasMaxLength(1);
                e.HasMany(x => x.SubjectGroups).WithOne(x => x.CurriculumDetail).HasForeignKey(x => x.CurriculumDetailId);
            });

            builder.Entity<SubjectGroup>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "SubjectGroups", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();
            });

            builder.Entity<Subject>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Subjects", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.HasIndex(x => x.Code).IsUnique();

                e.Property(x => x.Name).IsRequired().HasMaxLength(1024);
                e.Property(x => x.Code).IsRequired().HasMaxLength(5);
                e.Property(x => x.Unit).IsRequired();
                e.Property(x => x.Coefficient).IsRequired();

                e.HasMany(x => x.SubjectGroups).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
                e.HasMany(x => x.UserSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
                e.HasOne(x => x.Outline).WithOne(x => x.Subject).HasForeignKey<Outline>(x => x.SubjectId);
            });

            builder.Entity<Outline>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Outlines", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.HasMany(x => x.OutlineDocuments).WithOne(x => x.Outline).HasForeignKey(x => x.OutlineId);
            });

            builder.Entity<Document>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Documents", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.InLibrary).IsRequired().HasMaxLength(1);
                e.HasMany(x => x.OutlineDocuments).WithOne(x => x.Document).HasForeignKey(x => x.DocumentId);
            });

            builder.Entity<OutlineDocument>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "OutlineDocuments", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.DocumentType).IsRequired().HasMaxLength(1);
            });

            builder.Entity<UserSubject>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "UserSubjects", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();
            });
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
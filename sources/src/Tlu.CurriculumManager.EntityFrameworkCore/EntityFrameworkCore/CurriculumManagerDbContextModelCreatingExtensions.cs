using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Tlu.CurriculumManager.EntityFrameworkCore
{
    public static class CurriculumManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureCurriculumManager(this ModelBuilder builder, bool isMigrationDbContext)
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
                e.HasMany(x => x.Outlines).WithOne(x => x.SchoolYear).HasForeignKey(x => x.SchoolYearId);
            });

            builder.Entity<Curriculum>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Curriculums", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired().HasMaxLength(512);
                e.Property(x => x.ApproveStatus).IsRequired();
                e.HasMany(x => x.SubjectGroups).WithOne(x => x.Curriculum).HasForeignKey(x => x.CurriculumId);
            });

            builder.Entity<SubjectGroup>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "SubjectGroups", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.CurriculumId).IsRequired();
                e.HasMany(x => x.SubjectGroupDetails).WithOne(x => x.SubjectGroup).HasForeignKey(x => x.SubjectGroupId);
                e.HasOne(x => x.Parent).WithMany(x => x.Childrens).HasForeignKey(x => x.ParentId);
            });

            builder.Entity<SubjectGroupDetail>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "SubjectGroupDetails", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

            });

            builder.Entity<Subject>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Subjects", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.HasIndex(x => x.Code).IsUnique();

                e.Property(x => x.Name).IsRequired().HasMaxLength(1024);
                e.Property(x => x.Unit).IsRequired();
                e.Property(x => x.Coefficient).IsRequired();

                e.HasMany(x => x.SubjectGroupDetails).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
                e.HasMany(x => x.TeacherSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
                e.HasMany(x => x.Outlines).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
            });

            builder.Entity<Outline>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Outlines", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.Property(x => x.ApproveStatus).IsRequired();
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

            builder.Entity<TeacherSubject>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "TeacherSubjects", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();
            });

            builder.Entity<Genre>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Genres", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.HasMany(x => x.Teachers).WithOne(x => x.Genre).HasForeignKey(x => x.GenreId);
            });

            builder.Entity<Teacher>(e =>
            {
                e.ToTable(CurriculumManagerConsts.DbTablePrefix + "Teachers", CurriculumManagerConsts.DbSchema);
                e.ConfigureByConvention();

                e.HasMany(x => x.TeacherSubjects).WithOne(x => x.Teacher).HasForeignKey(x => x.TeacherId);
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
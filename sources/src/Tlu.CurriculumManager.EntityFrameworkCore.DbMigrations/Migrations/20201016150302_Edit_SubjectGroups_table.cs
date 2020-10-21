using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Edit_SubjectGroups_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "AppSubjectGroups");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "AppSubjectGroups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitTotal",
                table: "AppSubjectGroups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AppSubjectGroups");

            migrationBuilder.DropColumn(
                name: "UnitTotal",
                table: "AppSubjectGroups");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "AppSubjectGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

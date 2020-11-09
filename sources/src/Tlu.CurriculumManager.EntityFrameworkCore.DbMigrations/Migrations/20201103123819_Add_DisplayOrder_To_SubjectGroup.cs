using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Add_DisplayOrder_To_SubjectGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "AppSubjectGroups",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "AppSubjectGroups");
        }
    }
}

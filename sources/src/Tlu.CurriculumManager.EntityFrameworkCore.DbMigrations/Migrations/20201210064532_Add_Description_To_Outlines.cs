using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Add_Description_To_Outlines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppOutlines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppOutlines");
        }
    }
}

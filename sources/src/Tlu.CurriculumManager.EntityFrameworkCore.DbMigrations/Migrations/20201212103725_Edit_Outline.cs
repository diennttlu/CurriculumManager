using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Edit_Outline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOutlines_AppSchoolYears_OutlineId",
                table: "AppOutlines");

            migrationBuilder.DropIndex(
                name: "IX_AppOutlines_OutlineId",
                table: "AppOutlines");

            migrationBuilder.DropColumn(
                name: "OutlineId",
                table: "AppOutlines");

            migrationBuilder.AddColumn<int>(
                name: "SchoolYearId",
                table: "AppOutlines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlines_SchoolYearId",
                table: "AppOutlines",
                column: "SchoolYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOutlines_AppSchoolYears_SchoolYearId",
                table: "AppOutlines",
                column: "SchoolYearId",
                principalTable: "AppSchoolYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOutlines_AppSchoolYears_SchoolYearId",
                table: "AppOutlines");

            migrationBuilder.DropIndex(
                name: "IX_AppOutlines_SchoolYearId",
                table: "AppOutlines");

            migrationBuilder.DropColumn(
                name: "SchoolYearId",
                table: "AppOutlines");

            migrationBuilder.AddColumn<int>(
                name: "OutlineId",
                table: "AppOutlines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlines_OutlineId",
                table: "AppOutlines",
                column: "OutlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOutlines_AppSchoolYears_OutlineId",
                table: "AppOutlines",
                column: "OutlineId",
                principalTable: "AppSchoolYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

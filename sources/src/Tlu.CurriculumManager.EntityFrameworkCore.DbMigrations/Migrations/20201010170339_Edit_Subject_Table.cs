using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Edit_Subject_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppSubjects_Code",
                table: "AppSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AppSubjects",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjects_Code",
                table: "AppSubjects",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppSubjects_Code",
                table: "AppSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AppSubjects",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjects_Code",
                table: "AppSubjects",
                column: "Code",
                unique: true);
        }
    }
}

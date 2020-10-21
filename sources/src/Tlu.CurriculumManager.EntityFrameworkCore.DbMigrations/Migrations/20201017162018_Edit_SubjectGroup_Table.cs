using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Edit_SubjectGroup_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppSubjectGroups_ParentId",
                table: "AppSubjectGroups",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubjectGroups_AppSubjectGroups_ParentId",
                table: "AppSubjectGroups",
                column: "ParentId",
                principalTable: "AppSubjectGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSubjectGroups_AppSubjectGroups_ParentId",
                table: "AppSubjectGroups");

            migrationBuilder.DropIndex(
                name: "IX_AppSubjectGroups_ParentId",
                table: "AppSubjectGroups");
        }
    }
}

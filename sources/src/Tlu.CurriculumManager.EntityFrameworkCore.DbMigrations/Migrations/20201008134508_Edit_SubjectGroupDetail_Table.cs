using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Edit_SubjectGroupDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGroupDetail_AppSubjectGroups_SubjectGroupId",
                table: "SubjectGroupDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGroupDetail_AppSubjects_SubjectId",
                table: "SubjectGroupDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectGroupDetail",
                table: "SubjectGroupDetail");

            migrationBuilder.RenameTable(
                name: "SubjectGroupDetail",
                newName: "AppSubjectGroupDetails");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGroupDetail_SubjectId",
                table: "AppSubjectGroupDetails",
                newName: "IX_AppSubjectGroupDetails_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGroupDetail_SubjectGroupId",
                table: "AppSubjectGroupDetails",
                newName: "IX_AppSubjectGroupDetails_SubjectGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSubjectGroupDetails",
                table: "AppSubjectGroupDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubjectGroupDetails_AppSubjectGroups_SubjectGroupId",
                table: "AppSubjectGroupDetails",
                column: "SubjectGroupId",
                principalTable: "AppSubjectGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubjectGroupDetails_AppSubjects_SubjectId",
                table: "AppSubjectGroupDetails",
                column: "SubjectId",
                principalTable: "AppSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSubjectGroupDetails_AppSubjectGroups_SubjectGroupId",
                table: "AppSubjectGroupDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSubjectGroupDetails_AppSubjects_SubjectId",
                table: "AppSubjectGroupDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSubjectGroupDetails",
                table: "AppSubjectGroupDetails");

            migrationBuilder.RenameTable(
                name: "AppSubjectGroupDetails",
                newName: "SubjectGroupDetail");

            migrationBuilder.RenameIndex(
                name: "IX_AppSubjectGroupDetails_SubjectId",
                table: "SubjectGroupDetail",
                newName: "IX_SubjectGroupDetail_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AppSubjectGroupDetails_SubjectGroupId",
                table: "SubjectGroupDetail",
                newName: "IX_SubjectGroupDetail_SubjectGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectGroupDetail",
                table: "SubjectGroupDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGroupDetail_AppSubjectGroups_SubjectGroupId",
                table: "SubjectGroupDetail",
                column: "SubjectGroupId",
                principalTable: "AppSubjectGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGroupDetail_AppSubjects_SubjectId",
                table: "SubjectGroupDetail",
                column: "SubjectId",
                principalTable: "AppSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

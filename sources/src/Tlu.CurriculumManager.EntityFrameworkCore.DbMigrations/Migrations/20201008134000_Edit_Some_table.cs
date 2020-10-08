using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Edit_Some_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSubjectGroups_AppCurriculumDetails_CurriculumDetailId",
                table: "AppSubjectGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSubjectGroups_AppSubjects_SubjectId",
                table: "AppSubjectGroups");

            migrationBuilder.DropTable(
                name: "AppCurriculumDetails");

            migrationBuilder.DropTable(
                name: "AppKnowledgeGroups");

            migrationBuilder.DropIndex(
                name: "IX_AppSubjectGroups_CurriculumDetailId",
                table: "AppSubjectGroups");

            migrationBuilder.DropIndex(
                name: "IX_AppSubjectGroups_SubjectId",
                table: "AppSubjectGroups");

            migrationBuilder.DropColumn(
                name: "CurriculumDetailId",
                table: "AppSubjectGroups");

            migrationBuilder.AddColumn<int>(
                name: "CurriculumId",
                table: "AppSubjectGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppSubjectGroups",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "AppSubjectGroups",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubjectGroupDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: false),
                    SubjectGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGroupDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectGroupDetail_AppSubjectGroups_SubjectGroupId",
                        column: x => x.SubjectGroupId,
                        principalTable: "AppSubjectGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectGroupDetail_AppSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "AppSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjectGroups_CurriculumId",
                table: "AppSubjectGroups",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroupDetail_SubjectGroupId",
                table: "SubjectGroupDetail",
                column: "SubjectGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroupDetail_SubjectId",
                table: "SubjectGroupDetail",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubjectGroups_AppCurriculums_CurriculumId",
                table: "AppSubjectGroups",
                column: "CurriculumId",
                principalTable: "AppCurriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSubjectGroups_AppCurriculums_CurriculumId",
                table: "AppSubjectGroups");

            migrationBuilder.DropTable(
                name: "SubjectGroupDetail");

            migrationBuilder.DropIndex(
                name: "IX_AppSubjectGroups_CurriculumId",
                table: "AppSubjectGroups");

            migrationBuilder.DropColumn(
                name: "CurriculumId",
                table: "AppSubjectGroups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppSubjectGroups");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "AppSubjectGroups");

            migrationBuilder.AddColumn<int>(
                name: "CurriculumDetailId",
                table: "AppSubjectGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppKnowledgeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayOrder = table.Column<int>(type: "int", maxLength: 2, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppKnowledgeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCurriculumDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    KnowledgeGroupId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCurriculumDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCurriculumDetails_AppCurriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "AppCurriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCurriculumDetails_AppKnowledgeGroups_KnowledgeGroupId",
                        column: x => x.KnowledgeGroupId,
                        principalTable: "AppKnowledgeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjectGroups_CurriculumDetailId",
                table: "AppSubjectGroups",
                column: "CurriculumDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjectGroups_SubjectId",
                table: "AppSubjectGroups",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurriculumDetails_CurriculumId",
                table: "AppCurriculumDetails",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurriculumDetails_KnowledgeGroupId",
                table: "AppCurriculumDetails",
                column: "KnowledgeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubjectGroups_AppCurriculumDetails_CurriculumDetailId",
                table: "AppSubjectGroups",
                column: "CurriculumDetailId",
                principalTable: "AppCurriculumDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSubjectGroups_AppSubjects_SubjectId",
                table: "AppSubjectGroups",
                column: "SubjectId",
                principalTable: "AppSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

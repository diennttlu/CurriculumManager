using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Add_Teacher_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserSubjects");

            migrationBuilder.DropIndex(
                name: "IX_AppOutlines_SubjectId",
                table: "AppOutlines");

            migrationBuilder.CreateTable(
                name: "AppTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTeachers_AppGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "AppGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTeacherSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTeacherSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTeacherSubjects_AppSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "AppSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTeacherSubjects_AppTeachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AppTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlines_SubjectId",
                table: "AppOutlines",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTeachers_GenreId",
                table: "AppTeachers",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTeacherSubjects_SubjectId",
                table: "AppTeacherSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTeacherSubjects_TeacherId",
                table: "AppTeacherSubjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTeacherSubjects");

            migrationBuilder.DropTable(
                name: "AppTeachers");

            migrationBuilder.DropIndex(
                name: "IX_AppOutlines_SubjectId",
                table: "AppOutlines");

            migrationBuilder.CreateTable(
                name: "AppUserSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserSubjects_AppSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "AppSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlines_SubjectId",
                table: "AppOutlines",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSubjects_SubjectId",
                table: "AppUserSubjects",
                column: "SubjectId");
        }
    }
}

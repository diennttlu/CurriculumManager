using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Add_property_to_AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppSubjects");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppSubjects");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppSchoolYears");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppSchoolYears");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppOutlines");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppOutlines");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppMajors");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppMajors");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppKnowledgeGroups");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppKnowledgeGroups");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppFaculties");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppFaculties");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppDocuments");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppDocuments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppCurriculums");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AppCurriculums");

            migrationBuilder.AddColumn<int>(
                name: "ApproveStatus",
                table: "AppOutlines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OutlineId",
                table: "AppOutlines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApproveStatus",
                table: "AppCurriculums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppGenres_AppFaculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AppFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlines_OutlineId",
                table: "AppOutlines",
                column: "OutlineId");

            migrationBuilder.CreateIndex(
                name: "IX_AppGenres_FacultyId",
                table: "AppGenres",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOutlines_AppSchoolYears_OutlineId",
                table: "AppOutlines",
                column: "OutlineId",
                principalTable: "AppSchoolYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOutlines_AppSchoolYears_OutlineId",
                table: "AppOutlines");

            migrationBuilder.DropTable(
                name: "AppGenres");

            migrationBuilder.DropIndex(
                name: "IX_AppOutlines_OutlineId",
                table: "AppOutlines");

            migrationBuilder.DropColumn(
                name: "ApproveStatus",
                table: "AppOutlines");

            migrationBuilder.DropColumn(
                name: "OutlineId",
                table: "AppOutlines");

            migrationBuilder.DropColumn(
                name: "ApproveStatus",
                table: "AppCurriculums");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "AbpUsers");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppSubjects",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppSubjects",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppSchoolYears",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppSchoolYears",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppOutlines",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppOutlines",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppMajors",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppMajors",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppKnowledgeGroups",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppKnowledgeGroups",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppFaculties",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppFaculties",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppDocuments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppDocuments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AppCurriculums",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "AppCurriculums",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}

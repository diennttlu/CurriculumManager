using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tlu.CurriculumManager.Migrations
{
    public partial class Add_All_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LibraryCode = table.Column<string>(nullable: true),
                    InLibrary = table.Column<int>(maxLength: 1, nullable: false),
                    Isbn = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFaculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFaculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppKnowledgeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 1024, nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(maxLength: 2, nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppKnowledgeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSchoolYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Course = table.Column<string>(maxLength: 4, nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSchoolYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 1024, nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    HoursStudy = table.Column<string>(nullable: true),
                    Coefficient = table.Column<double>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMajors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    FacultyId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMajors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMajors_AppFaculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AppFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppOutlines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<string>(nullable: true),
                    Assessment = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOutlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOutlines_AppSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "AppSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AppCurriculums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 512, nullable: false),
                    MajorId = table.Column<int>(nullable: false),
                    SchoolYearId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCurriculums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCurriculums_AppMajors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "AppMajors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCurriculums_AppSchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "AppSchoolYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppOutlineDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutlineId = table.Column<int>(nullable: false),
                    DocumentId = table.Column<int>(nullable: false),
                    DocumentType = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOutlineDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOutlineDocuments_AppDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "AppDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOutlineDocuments_AppOutlines_OutlineId",
                        column: x => x.OutlineId,
                        principalTable: "AppOutlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppCurriculumDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(nullable: false),
                    KnowledgeGroupId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 1, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AppSubjectGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumDetailId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubjectGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSubjectGroups_AppCurriculumDetails_CurriculumDetailId",
                        column: x => x.CurriculumDetailId,
                        principalTable: "AppCurriculumDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSubjectGroups_AppSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "AppSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCurriculumDetails_CurriculumId",
                table: "AppCurriculumDetails",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurriculumDetails_KnowledgeGroupId",
                table: "AppCurriculumDetails",
                column: "KnowledgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurriculums_MajorId",
                table: "AppCurriculums",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurriculums_SchoolYearId",
                table: "AppCurriculums",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMajors_FacultyId",
                table: "AppMajors",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlineDocuments_DocumentId",
                table: "AppOutlineDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlineDocuments_OutlineId",
                table: "AppOutlineDocuments",
                column: "OutlineId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOutlines_SubjectId",
                table: "AppOutlines",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjectGroups_CurriculumDetailId",
                table: "AppSubjectGroups",
                column: "CurriculumDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjectGroups_SubjectId",
                table: "AppSubjectGroups",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSubjects_Code",
                table: "AppSubjects",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSubjects_SubjectId",
                table: "AppUserSubjects",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOutlineDocuments");

            migrationBuilder.DropTable(
                name: "AppSubjectGroups");

            migrationBuilder.DropTable(
                name: "AppUserSubjects");

            migrationBuilder.DropTable(
                name: "AppDocuments");

            migrationBuilder.DropTable(
                name: "AppOutlines");

            migrationBuilder.DropTable(
                name: "AppCurriculumDetails");

            migrationBuilder.DropTable(
                name: "AppSubjects");

            migrationBuilder.DropTable(
                name: "AppCurriculums");

            migrationBuilder.DropTable(
                name: "AppKnowledgeGroups");

            migrationBuilder.DropTable(
                name: "AppMajors");

            migrationBuilder.DropTable(
                name: "AppSchoolYears");

            migrationBuilder.DropTable(
                name: "AppFaculties");
        }
    }
}

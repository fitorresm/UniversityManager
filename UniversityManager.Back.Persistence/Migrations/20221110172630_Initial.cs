using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManager.Back.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdSemesters = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    IdSemester = table.Column<int>(type: "int", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdTeacher = table.Column<int>(type: "int", nullable: true),
                    ValueNote = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => new { x.IdCourse, x.IdSemester, x.IdStudent, x.IdSubject });
                });

            migrationBuilder.CreateTable(
                name: "Relationship_Subjects_Courses",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship_Subjects_Courses", x => x.IdSubject);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GraduationCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationship_Students_Subjects",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    IdSemester = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship_Students_Subjects", x => new { x.IdStudent, x.IdSubject });
                    table.ForeignKey(
                        name: "FK_Relationship_Students_Subjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipStudentSubjectIdStudent = table.Column<int>(name: "Relationship_Student_SubjectIdStudent", type: "int", nullable: true),
                    RelationshipStudentSubjectIdSubject = table.Column<int>(name: "Relationship_Student_SubjectIdSubject", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_Relationship_Students_Subjects_Relationship_Student_SubjectIdStudent_Relationship_Student_SubjectIdSubject",
                        columns: x => new { x.RelationshipStudentSubjectIdStudent, x.RelationshipStudentSubjectIdSubject },
                        principalTable: "Relationship_Students_Subjects",
                        principalColumns: new[] { "IdStudent", "IdSubject" });
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinAprove = table.Column<float>(type: "real", nullable: false),
                    MaxAprove = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Optional = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipStudentSubjectIdStudent = table.Column<int>(name: "Relationship_Student_SubjectIdStudent", type: "int", nullable: true),
                    RelationshipStudentSubjectIdSubject = table.Column<int>(name: "Relationship_Student_SubjectIdSubject", type: "int", nullable: true),
                    RelationshipSubjectCourseIdSubject = table.Column<int>(name: "Relationship_Subject_CourseIdSubject", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Relationship_Students_Subjects_Relationship_Student_SubjectIdStudent_Relationship_Student_SubjectIdSubject",
                        columns: x => new { x.RelationshipStudentSubjectIdStudent, x.RelationshipStudentSubjectIdSubject },
                        principalTable: "Relationship_Students_Subjects",
                        principalColumns: new[] { "IdStudent", "IdSubject" });
                    table.ForeignKey(
                        name: "FK_Subjects_Relationship_Subjects_Courses_Relationship_Subject_CourseIdSubject",
                        column: x => x.RelationshipSubjectCourseIdSubject,
                        principalTable: "Relationship_Subjects_Courses",
                        principalColumn: "IdSubject");
                });

            migrationBuilder.CreateTable(
                name: "Relationship_Teachers_Subjects",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    IdSemester = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdTeacher = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship_Teachers_Subjects", x => new { x.IdSubject, x.IdSemester });
                    table.ForeignKey(
                        name: "FK_Relationship_Teachers_Subjects_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Relationship_Teachers_Subjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipTeacherSubjectIdSemester = table.Column<int>(name: "Relationship_Teacher_SubjectIdSemester", type: "int", nullable: true),
                    RelationshipTeacherSubjectIdSubject = table.Column<int>(name: "Relationship_Teacher_SubjectIdSubject", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Relationship_Teachers_Subjects_Relationship_Teacher_SubjectIdSubject_Relationship_Teacher_SubjectIdSemester",
                        columns: x => new { x.RelationshipTeacherSubjectIdSubject, x.RelationshipTeacherSubjectIdSemester },
                        principalTable: "Relationship_Teachers_Subjects",
                        principalColumns: new[] { "IdSubject", "IdSemester" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_Students_Subjects_StudentId",
                table: "Relationship_Students_Subjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_Teachers_Subjects_SemesterId",
                table: "Relationship_Teachers_Subjects",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_Teachers_Subjects_SubjectId",
                table: "Relationship_Teachers_Subjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_Relationship_Student_SubjectIdStudent_Relationship_Student_SubjectIdSubject",
                table: "Semesters",
                columns: new[] { "Relationship_Student_SubjectIdStudent", "Relationship_Student_SubjectIdSubject" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Relationship_Student_SubjectIdStudent_Relationship_Student_SubjectIdSubject",
                table: "Subjects",
                columns: new[] { "Relationship_Student_SubjectIdStudent", "Relationship_Student_SubjectIdSubject" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Relationship_Subject_CourseIdSubject",
                table: "Subjects",
                column: "Relationship_Subject_CourseIdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Relationship_Teacher_SubjectIdSubject_Relationship_Teacher_SubjectIdSemester",
                table: "Teachers",
                columns: new[] { "Relationship_Teacher_SubjectIdSubject", "Relationship_Teacher_SubjectIdSemester" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Relationship_Teachers_Subjects");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Relationship_Students_Subjects");

            migrationBuilder.DropTable(
                name: "Relationship_Subjects_Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

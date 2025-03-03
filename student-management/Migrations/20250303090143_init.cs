using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace student_management.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "term",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_term", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exam_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_exam_room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exam_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_exam_term_TermId",
                        column: x => x.TermId,
                        principalTable: "term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exam_user_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudySessions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_schedule_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_schedule_room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_schedule_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_schedule_term_TermId",
                        column: x => x.TermId,
                        principalTable: "term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedule_user_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "score",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_score_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_score_term_TermId",
                        column: x => x.TermId,
                        principalTable: "term",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_score_user_StudentId",
                        column: x => x.StudentId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "room",
                columns: new[] { "Id", "Capacity", "RoomName" },
                values: new object[,]
                {
                    { 1, 32, "Phòng 1A" },
                    { 2, 34, "Phòng 2A" },
                    { 3, 36, "Phòng 3A" },
                    { 4, 38, "Phòng 4A" },
                    { 5, 40, "Phòng 5A" },
                    { 6, 42, "Phòng 6A" },
                    { 7, 44, "Phòng 7A" },
                    { 8, 46, "Phòng 8A" },
                    { 9, 48, "Phòng 9A" },
                    { 10, 50, "Phòng 10A" }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "Id", "SubjectName" },
                values: new object[,]
                {
                    { 1, "Môn học 1" },
                    { 2, "Môn học 2" },
                    { 3, "Môn học 3" },
                    { 4, "Môn học 4" },
                    { 5, "Môn học 5" },
                    { 6, "Môn học 6" },
                    { 7, "Môn học 7" },
                    { 8, "Môn học 8" },
                    { 9, "Môn học 9" },
                    { 10, "Môn học 10" },
                    { 11, "Môn học 11" },
                    { 12, "Môn học 12" },
                    { 13, "Môn học 13" },
                    { 14, "Môn học 14" },
                    { 15, "Môn học 15" },
                    { 16, "Môn học 16" },
                    { 17, "Môn học 17" },
                    { 18, "Môn học 18" },
                    { 19, "Môn học 19" },
                    { 20, "Môn học 20" }
                });

            migrationBuilder.InsertData(
                table: "term",
                columns: new[] { "Id", "TermName" },
                values: new object[,]
                {
                    { 1, "Học kỳ 1 - 2024" },
                    { 2, "Học kỳ 2 - 2024" },
                    { 3, "Học kỳ 1 - 2025" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "ClassId", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, null, "teacher1@example.com", false, "Giáo viên 1", "teacher1123", "098765431", "Teacher", "teacher1" },
                    { 2, null, "teacher2@example.com", false, "Giáo viên 2", "teacher2123", "098765432", "Teacher", "teacher2" },
                    { 3, null, "teacher3@example.com", false, "Giáo viên 3", "teacher3123", "098765433", "Teacher", "teacher3" },
                    { 4, null, "teacher4@example.com", false, "Giáo viên 4", "teacher4123", "098765434", "Teacher", "teacher4" },
                    { 5, null, "teacher5@example.com", false, "Giáo viên 5", "teacher5123", "098765435", "Teacher", "teacher5" },
                    { 6, null, "teacher6@example.com", false, "Giáo viên 6", "teacher6123", "098765436", "Teacher", "teacher6" },
                    { 7, null, "teacher7@example.com", false, "Giáo viên 7", "teacher7123", "098765437", "Teacher", "teacher7" },
                    { 8, null, "teacher8@example.com", false, "Giáo viên 8", "teacher8123", "098765438", "Teacher", "teacher8" },
                    { 9, null, "teacher9@example.com", false, "Giáo viên 9", "teacher9123", "098765439", "Teacher", "teacher9" },
                    { 10, null, "teacher10@example.com", false, "Giáo viên 10", "teacher10123", "0987654310", "Teacher", "teacher10" }
                });

            migrationBuilder.InsertData(
                table: "class",
                columns: new[] { "Id", "ClassName", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Lớp CNTT-1", 1 },
                    { 2, "Lớp CNTT-2", 2 },
                    { 3, "Lớp CNTT-3", 3 },
                    { 4, "Lớp CNTT-4", 4 },
                    { 5, "Lớp CNTT-5", 5 },
                    { 6, "Lớp CNTT-6", 6 },
                    { 7, "Lớp CNTT-7", 7 },
                    { 8, "Lớp CNTT-8", 8 },
                    { 9, "Lớp CNTT-9", 9 },
                    { 10, "Lớp CNTT-10", 10 }
                });

            migrationBuilder.InsertData(
                table: "exam",
                columns: new[] { "Id", "ClassId", "EndTime", "ExamDate", "RoomId", "StartTime", "SubjectId", "TeacherId", "TermId" },
                values: new object[,]
                {
                    { 1, 2, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 9, 0, 0, 0), 2, 2, 2 },
                    { 2, 3, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 9, 0, 0, 0), 3, 3, 3 },
                    { 3, 4, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 9, 0, 0, 0), 4, 4, 1 },
                    { 4, 5, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new TimeSpan(0, 9, 0, 0, 0), 5, 5, 2 },
                    { 5, 6, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new TimeSpan(0, 9, 0, 0, 0), 6, 6, 3 },
                    { 6, 7, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new TimeSpan(0, 9, 0, 0, 0), 7, 7, 1 },
                    { 7, 8, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new TimeSpan(0, 9, 0, 0, 0), 8, 8, 2 },
                    { 8, 9, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new TimeSpan(0, 9, 0, 0, 0), 9, 9, 3 },
                    { 9, 10, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new TimeSpan(0, 9, 0, 0, 0), 10, 10, 1 },
                    { 10, 1, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 9, 0, 0, 0), 11, 1, 2 },
                    { 11, 2, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 9, 0, 0, 0), 12, 2, 3 },
                    { 12, 3, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 9, 0, 0, 0), 13, 3, 1 },
                    { 13, 4, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 9, 0, 0, 0), 14, 4, 2 },
                    { 14, 5, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new TimeSpan(0, 9, 0, 0, 0), 15, 5, 3 },
                    { 15, 6, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new TimeSpan(0, 9, 0, 0, 0), 16, 6, 1 },
                    { 16, 7, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new TimeSpan(0, 9, 0, 0, 0), 17, 7, 2 },
                    { 17, 8, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new TimeSpan(0, 9, 0, 0, 0), 18, 8, 3 },
                    { 18, 9, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new TimeSpan(0, 9, 0, 0, 0), 19, 9, 1 },
                    { 19, 10, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new TimeSpan(0, 9, 0, 0, 0), 20, 10, 2 },
                    { 20, 1, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 9, 0, 0, 0), 1, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "schedule",
                columns: new[] { "Id", "ClassId", "CreatedAt", "DaysOfWeek", "EndDate", "RoomId", "StartDate", "StudySessions", "SubjectId", "TeacherId", "TermId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(3401), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 2, 2, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(3405) },
                    { 2, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5515), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 3, 3, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5515) },
                    { 3, 4, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5530), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 4, 4, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5531) },
                    { 4, 5, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5542), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 5, 5, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5542) },
                    { 5, 6, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5554), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 6, 6, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5555) },
                    { 6, 7, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5568), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 7, 7, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5568) },
                    { 7, 8, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5579), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 8, 8, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5580) },
                    { 8, 9, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5591), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 9, 9, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5591) },
                    { 9, 10, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5602), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 10, 10, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5602) },
                    { 10, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5613), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 11, 1, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5613) },
                    { 11, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5624), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 12, 2, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5624) },
                    { 12, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5635), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 13, 3, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5635) },
                    { 13, 4, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5646), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 14, 4, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5646) },
                    { 14, 5, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5656), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 15, 5, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5656) },
                    { 15, 6, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5668), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 16, 6, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5668) },
                    { 16, 7, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5678), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 17, 7, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5679) },
                    { 17, 8, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5690), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 18, 8, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5690) },
                    { 18, 9, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5701), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 19, 9, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5702) },
                    { 19, 10, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5742), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 20, 10, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5742) },
                    { 20, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5754), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, 1, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5754) },
                    { 21, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5765), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 2, 2, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5765) },
                    { 22, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5776), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 3, 3, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5776) },
                    { 23, 4, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5786), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 4, 4, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5786) },
                    { 24, 5, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5797), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 5, 5, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5798) },
                    { 25, 6, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5808), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 6, 6, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5809) },
                    { 26, 7, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5819), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 7, 7, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5819) },
                    { 27, 8, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5830), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 8, 8, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5830) },
                    { 28, 9, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5840), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 9, 9, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5840) },
                    { 29, 10, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5852), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 10, 10, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5852) },
                    { 30, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5862), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 11, 1, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5862) },
                    { 31, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5872), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 12, 2, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5872) },
                    { 32, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5882), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 13, 3, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5882) },
                    { 33, 4, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5893), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 14, 4, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5893) },
                    { 34, 5, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5904), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 15, 5, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5904) },
                    { 35, 6, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5916), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 16, 6, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5916) },
                    { 36, 7, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5927), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 17, 7, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5927) },
                    { 37, 8, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5937), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 18, 8, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5937) },
                    { 38, 9, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5948), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 19, 9, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5948) },
                    { 39, 10, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5958), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 20, 10, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(5959) },
                    { 40, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6013), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1, 1, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6013) },
                    { 41, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6026), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 2, 2, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6026) },
                    { 42, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6038), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 3, 3, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6038) },
                    { 43, 4, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6048), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 4, 4, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6049) },
                    { 44, 5, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6060), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 5, 5, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6060) },
                    { 45, 6, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6070), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 6, 6, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6070) },
                    { 46, 7, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6082), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 7, 7, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6082) },
                    { 47, 8, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6092), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 8, 8, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6093) },
                    { 48, 9, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6104), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 9, 9, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6104) },
                    { 49, 10, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6114), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 10, 10, 2, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6115) },
                    { 50, 1, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6126), "Monday,Wednesday", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 11, 1, 3, new DateTime(2025, 3, 3, 9, 1, 42, 824, DateTimeKind.Utc).AddTicks(6126) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "ClassId", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 11, 2, "student11@example.com", false, "Sinh viên 11", "student11123", "0901234511", "Student", "student11" },
                    { 12, 3, "student12@example.com", false, "Sinh viên 12", "student12123", "0901234512", "Student", "student12" },
                    { 13, 4, "student13@example.com", false, "Sinh viên 13", "student13123", "0901234513", "Student", "student13" },
                    { 14, 5, "student14@example.com", false, "Sinh viên 14", "student14123", "0901234514", "Student", "student14" },
                    { 15, 6, "student15@example.com", false, "Sinh viên 15", "student15123", "0901234515", "Student", "student15" },
                    { 16, 7, "student16@example.com", false, "Sinh viên 16", "student16123", "0901234516", "Student", "student16" },
                    { 17, 8, "student17@example.com", false, "Sinh viên 17", "student17123", "0901234517", "Student", "student17" },
                    { 18, 9, "student18@example.com", false, "Sinh viên 18", "student18123", "0901234518", "Student", "student18" },
                    { 19, 10, "student19@example.com", false, "Sinh viên 19", "student19123", "0901234519", "Student", "student19" },
                    { 20, 1, "student20@example.com", false, "Sinh viên 20", "student20123", "0901234520", "Student", "student20" },
                    { 21, 2, "student21@example.com", false, "Sinh viên 21", "student21123", "0901234521", "Student", "student21" },
                    { 22, 3, "student22@example.com", false, "Sinh viên 22", "student22123", "0901234522", "Student", "student22" },
                    { 23, 4, "student23@example.com", false, "Sinh viên 23", "student23123", "0901234523", "Student", "student23" },
                    { 24, 5, "student24@example.com", false, "Sinh viên 24", "student24123", "0901234524", "Student", "student24" },
                    { 25, 6, "student25@example.com", false, "Sinh viên 25", "student25123", "0901234525", "Student", "student25" },
                    { 26, 7, "student26@example.com", false, "Sinh viên 26", "student26123", "0901234526", "Student", "student26" },
                    { 27, 8, "student27@example.com", false, "Sinh viên 27", "student27123", "0901234527", "Student", "student27" },
                    { 28, 9, "student28@example.com", false, "Sinh viên 28", "student28123", "0901234528", "Student", "student28" },
                    { 29, 10, "student29@example.com", false, "Sinh viên 29", "student29123", "0901234529", "Student", "student29" },
                    { 30, 1, "student30@example.com", false, "Sinh viên 30", "student30123", "0901234530", "Student", "student30" },
                    { 31, 2, "student31@example.com", false, "Sinh viên 31", "student31123", "0901234531", "Student", "student31" },
                    { 32, 3, "student32@example.com", false, "Sinh viên 32", "student32123", "0901234532", "Student", "student32" },
                    { 33, 4, "student33@example.com", false, "Sinh viên 33", "student33123", "0901234533", "Student", "student33" },
                    { 34, 5, "student34@example.com", false, "Sinh viên 34", "student34123", "0901234534", "Student", "student34" },
                    { 35, 6, "student35@example.com", false, "Sinh viên 35", "student35123", "0901234535", "Student", "student35" },
                    { 36, 7, "student36@example.com", false, "Sinh viên 36", "student36123", "0901234536", "Student", "student36" },
                    { 37, 8, "student37@example.com", false, "Sinh viên 37", "student37123", "0901234537", "Student", "student37" },
                    { 38, 9, "student38@example.com", false, "Sinh viên 38", "student38123", "0901234538", "Student", "student38" },
                    { 39, 10, "student39@example.com", false, "Sinh viên 39", "student39123", "0901234539", "Student", "student39" },
                    { 40, 1, "student40@example.com", false, "Sinh viên 40", "student40123", "0901234540", "Student", "student40" },
                    { 41, 2, "student41@example.com", false, "Sinh viên 41", "student41123", "0901234541", "Student", "student41" },
                    { 42, 3, "student42@example.com", false, "Sinh viên 42", "student42123", "0901234542", "Student", "student42" },
                    { 43, 4, "student43@example.com", false, "Sinh viên 43", "student43123", "0901234543", "Student", "student43" },
                    { 44, 5, "student44@example.com", false, "Sinh viên 44", "student44123", "0901234544", "Student", "student44" },
                    { 45, 6, "student45@example.com", false, "Sinh viên 45", "student45123", "0901234545", "Student", "student45" },
                    { 46, 7, "student46@example.com", false, "Sinh viên 46", "student46123", "0901234546", "Student", "student46" },
                    { 47, 8, "student47@example.com", false, "Sinh viên 47", "student47123", "0901234547", "Student", "student47" },
                    { 48, 9, "student48@example.com", false, "Sinh viên 48", "student48123", "0901234548", "Student", "student48" },
                    { 49, 10, "student49@example.com", false, "Sinh viên 49", "student49123", "0901234549", "Student", "student49" },
                    { 50, 1, "student50@example.com", false, "Sinh viên 50", "student50123", "0901234550", "Student", "student50" },
                    { 51, 2, "student51@example.com", false, "Sinh viên 51", "student51123", "0901234551", "Student", "student51" },
                    { 52, 3, "student52@example.com", false, "Sinh viên 52", "student52123", "0901234552", "Student", "student52" },
                    { 53, 4, "student53@example.com", false, "Sinh viên 53", "student53123", "0901234553", "Student", "student53" },
                    { 54, 5, "student54@example.com", false, "Sinh viên 54", "student54123", "0901234554", "Student", "student54" },
                    { 55, 6, "student55@example.com", false, "Sinh viên 55", "student55123", "0901234555", "Student", "student55" },
                    { 56, 7, "student56@example.com", false, "Sinh viên 56", "student56123", "0901234556", "Student", "student56" },
                    { 57, 8, "student57@example.com", false, "Sinh viên 57", "student57123", "0901234557", "Student", "student57" },
                    { 58, 9, "student58@example.com", false, "Sinh viên 58", "student58123", "0901234558", "Student", "student58" },
                    { 59, 10, "student59@example.com", false, "Sinh viên 59", "student59123", "0901234559", "Student", "student59" },
                    { 60, 1, "student60@example.com", false, "Sinh viên 60", "student60123", "0901234560", "Student", "student60" },
                    { 61, 2, "student61@example.com", false, "Sinh viên 61", "student61123", "0901234561", "Student", "student61" },
                    { 62, 3, "student62@example.com", false, "Sinh viên 62", "student62123", "0901234562", "Student", "student62" },
                    { 63, 4, "student63@example.com", false, "Sinh viên 63", "student63123", "0901234563", "Student", "student63" },
                    { 64, 5, "student64@example.com", false, "Sinh viên 64", "student64123", "0901234564", "Student", "student64" },
                    { 65, 6, "student65@example.com", false, "Sinh viên 65", "student65123", "0901234565", "Student", "student65" },
                    { 66, 7, "student66@example.com", false, "Sinh viên 66", "student66123", "0901234566", "Student", "student66" },
                    { 67, 8, "student67@example.com", false, "Sinh viên 67", "student67123", "0901234567", "Student", "student67" },
                    { 68, 9, "student68@example.com", false, "Sinh viên 68", "student68123", "0901234568", "Student", "student68" },
                    { 69, 10, "student69@example.com", false, "Sinh viên 69", "student69123", "0901234569", "Student", "student69" },
                    { 70, 1, "student70@example.com", false, "Sinh viên 70", "student70123", "0901234570", "Student", "student70" },
                    { 71, 2, "student71@example.com", false, "Sinh viên 71", "student71123", "0901234571", "Student", "student71" },
                    { 72, 3, "student72@example.com", false, "Sinh viên 72", "student72123", "0901234572", "Student", "student72" },
                    { 73, 4, "student73@example.com", false, "Sinh viên 73", "student73123", "0901234573", "Student", "student73" },
                    { 74, 5, "student74@example.com", false, "Sinh viên 74", "student74123", "0901234574", "Student", "student74" },
                    { 75, 6, "student75@example.com", false, "Sinh viên 75", "student75123", "0901234575", "Student", "student75" },
                    { 76, 7, "student76@example.com", false, "Sinh viên 76", "student76123", "0901234576", "Student", "student76" },
                    { 77, 8, "student77@example.com", false, "Sinh viên 77", "student77123", "0901234577", "Student", "student77" },
                    { 78, 9, "student78@example.com", false, "Sinh viên 78", "student78123", "0901234578", "Student", "student78" },
                    { 79, 10, "student79@example.com", false, "Sinh viên 79", "student79123", "0901234579", "Student", "student79" },
                    { 80, 1, "student80@example.com", false, "Sinh viên 80", "student80123", "0901234580", "Student", "student80" },
                    { 81, 2, "student81@example.com", false, "Sinh viên 81", "student81123", "0901234581", "Student", "student81" },
                    { 82, 3, "student82@example.com", false, "Sinh viên 82", "student82123", "0901234582", "Student", "student82" },
                    { 83, 4, "student83@example.com", false, "Sinh viên 83", "student83123", "0901234583", "Student", "student83" },
                    { 84, 5, "student84@example.com", false, "Sinh viên 84", "student84123", "0901234584", "Student", "student84" },
                    { 85, 6, "student85@example.com", false, "Sinh viên 85", "student85123", "0901234585", "Student", "student85" },
                    { 86, 7, "student86@example.com", false, "Sinh viên 86", "student86123", "0901234586", "Student", "student86" },
                    { 87, 8, "student87@example.com", false, "Sinh viên 87", "student87123", "0901234587", "Student", "student87" },
                    { 88, 9, "student88@example.com", false, "Sinh viên 88", "student88123", "0901234588", "Student", "student88" },
                    { 89, 10, "student89@example.com", false, "Sinh viên 89", "student89123", "0901234589", "Student", "student89" },
                    { 90, 1, "student90@example.com", false, "Sinh viên 90", "student90123", "0901234590", "Student", "student90" },
                    { 91, 2, "student91@example.com", false, "Sinh viên 91", "student91123", "0901234591", "Student", "student91" },
                    { 92, 3, "student92@example.com", false, "Sinh viên 92", "student92123", "0901234592", "Student", "student92" },
                    { 93, 4, "student93@example.com", false, "Sinh viên 93", "student93123", "0901234593", "Student", "student93" },
                    { 94, 5, "student94@example.com", false, "Sinh viên 94", "student94123", "0901234594", "Student", "student94" },
                    { 95, 6, "student95@example.com", false, "Sinh viên 95", "student95123", "0901234595", "Student", "student95" },
                    { 96, 7, "student96@example.com", false, "Sinh viên 96", "student96123", "0901234596", "Student", "student96" },
                    { 97, 8, "student97@example.com", false, "Sinh viên 97", "student97123", "0901234597", "Student", "student97" },
                    { 98, 9, "student98@example.com", false, "Sinh viên 98", "student98123", "0901234598", "Student", "student98" },
                    { 99, 10, "student99@example.com", false, "Sinh viên 99", "student99123", "0901234599", "Student", "student99" },
                    { 100, 1, "student100@example.com", false, "Sinh viên 100", "student100123", "09012345100", "Student", "student100" },
                    { 101, 2, "student101@example.com", false, "Sinh viên 101", "student101123", "09012345101", "Student", "student101" },
                    { 102, 3, "student102@example.com", false, "Sinh viên 102", "student102123", "09012345102", "Student", "student102" },
                    { 103, 4, "student103@example.com", false, "Sinh viên 103", "student103123", "09012345103", "Student", "student103" },
                    { 104, 5, "student104@example.com", false, "Sinh viên 104", "student104123", "09012345104", "Student", "student104" },
                    { 105, 6, "student105@example.com", false, "Sinh viên 105", "student105123", "09012345105", "Student", "student105" },
                    { 106, 7, "student106@example.com", false, "Sinh viên 106", "student106123", "09012345106", "Student", "student106" },
                    { 107, 8, "student107@example.com", false, "Sinh viên 107", "student107123", "09012345107", "Student", "student107" },
                    { 108, 9, "student108@example.com", false, "Sinh viên 108", "student108123", "09012345108", "Student", "student108" },
                    { 109, 10, "student109@example.com", false, "Sinh viên 109", "student109123", "09012345109", "Student", "student109" },
                    { 110, 1, "student110@example.com", false, "Sinh viên 110", "student110123", "09012345110", "Student", "student110" }
                });

            migrationBuilder.InsertData(
                table: "attendance",
                columns: new[] { "Id", "Date", "ScheduleId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 11 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 11 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 12 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 12 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 13 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 13 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 14 },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 14 },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 15 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 15 },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 16 },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 16 },
                    { 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 17 },
                    { 14, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 17 },
                    { 15, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 18 },
                    { 16, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 18 },
                    { 17, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 19 },
                    { 18, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 19 },
                    { 19, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 20 },
                    { 20, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 20 },
                    { 21, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 21 },
                    { 22, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 21 },
                    { 23, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 22 },
                    { 24, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 22 },
                    { 25, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 23 },
                    { 26, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 23 },
                    { 27, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 24 },
                    { 28, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 24 },
                    { 29, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 25 },
                    { 30, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 25 },
                    { 31, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 26 },
                    { 32, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 26 },
                    { 33, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 27 },
                    { 34, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 27 },
                    { 35, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 28 },
                    { 36, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 28 },
                    { 37, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 29 },
                    { 38, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 29 },
                    { 39, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 30 },
                    { 40, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 30 },
                    { 41, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 31 },
                    { 42, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 31 },
                    { 43, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 32 },
                    { 44, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 32 },
                    { 45, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 33 },
                    { 46, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 33 },
                    { 47, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 34 },
                    { 48, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 34 },
                    { 49, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 35 },
                    { 50, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 35 },
                    { 51, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 36 },
                    { 52, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 36 },
                    { 53, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 37 },
                    { 54, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 37 },
                    { 55, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 38 },
                    { 56, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 38 },
                    { 57, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 39 },
                    { 58, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 39 },
                    { 59, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 40 },
                    { 60, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 40 },
                    { 61, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 41 },
                    { 62, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 41 },
                    { 63, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 42 },
                    { 64, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 42 },
                    { 65, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 43 },
                    { 66, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 43 },
                    { 67, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 44 },
                    { 68, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 44 },
                    { 69, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 45 },
                    { 70, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 45 },
                    { 71, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 46 },
                    { 72, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 46 },
                    { 73, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 47 },
                    { 74, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 47 },
                    { 75, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 48 },
                    { 76, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 48 },
                    { 77, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 49 },
                    { 78, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 49 },
                    { 79, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 50 },
                    { 80, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 50 },
                    { 81, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 51 },
                    { 82, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 51 },
                    { 83, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 52 },
                    { 84, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 52 },
                    { 85, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 53 },
                    { 86, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 53 },
                    { 87, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 54 },
                    { 88, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 54 },
                    { 89, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 55 },
                    { 90, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 55 },
                    { 91, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 56 },
                    { 92, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 56 },
                    { 93, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 57 },
                    { 94, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 57 },
                    { 95, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 58 },
                    { 96, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 58 },
                    { 97, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 59 },
                    { 98, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 59 },
                    { 99, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 60 },
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 60 },
                    { 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 61 },
                    { 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 61 },
                    { 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 62 },
                    { 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 62 },
                    { 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 63 },
                    { 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 63 },
                    { 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 64 },
                    { 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 64 },
                    { 109, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 65 },
                    { 110, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 65 },
                    { 111, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 66 },
                    { 112, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 66 },
                    { 113, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 67 },
                    { 114, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 67 },
                    { 115, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 68 },
                    { 116, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 68 },
                    { 117, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 69 },
                    { 118, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 69 },
                    { 119, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 70 },
                    { 120, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 70 },
                    { 121, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 71 },
                    { 122, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 71 },
                    { 123, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 72 },
                    { 124, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 72 },
                    { 125, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 73 },
                    { 126, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 73 },
                    { 127, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 74 },
                    { 128, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 74 },
                    { 129, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 75 },
                    { 130, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 75 },
                    { 131, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 76 },
                    { 132, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 76 },
                    { 133, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 77 },
                    { 134, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 77 },
                    { 135, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 78 },
                    { 136, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 78 },
                    { 137, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 79 },
                    { 138, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 79 },
                    { 139, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 80 },
                    { 140, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 80 },
                    { 141, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 81 },
                    { 142, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 81 },
                    { 143, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 82 },
                    { 144, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 82 },
                    { 145, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 83 },
                    { 146, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 83 },
                    { 147, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 84 },
                    { 148, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 84 },
                    { 149, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 85 },
                    { 150, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 85 },
                    { 151, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 86 },
                    { 152, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 86 },
                    { 153, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 87 },
                    { 154, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 87 },
                    { 155, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 88 },
                    { 156, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 88 },
                    { 157, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 89 },
                    { 158, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 89 },
                    { 159, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 90 },
                    { 160, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 90 },
                    { 161, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 91 },
                    { 162, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 91 },
                    { 163, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 92 },
                    { 164, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 92 },
                    { 165, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 93 },
                    { 166, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 93 },
                    { 167, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 94 },
                    { 168, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 94 },
                    { 169, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 95 },
                    { 170, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 95 },
                    { 171, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 96 },
                    { 172, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 96 },
                    { 173, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 97 },
                    { 174, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 97 },
                    { 175, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 98 },
                    { 176, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 98 },
                    { 177, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 99 },
                    { 178, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 99 },
                    { 179, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 100 },
                    { 180, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 100 },
                    { 181, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 101 },
                    { 182, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 101 },
                    { 183, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 102 },
                    { 184, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 102 },
                    { 185, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 103 },
                    { 186, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 103 },
                    { 187, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 104 },
                    { 188, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 104 },
                    { 189, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 105 },
                    { 190, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 105 },
                    { 191, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 106 },
                    { 192, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 106 },
                    { 193, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 107 },
                    { 194, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 107 },
                    { 195, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 108 },
                    { 196, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 108 },
                    { 197, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 109 },
                    { 198, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 109 },
                    { 199, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 110 },
                    { 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 110 }
                });

            migrationBuilder.InsertData(
                table: "score",
                columns: new[] { "Id", "Date", "StudentId", "SubjectId", "TermId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2, 2, 8.5m },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 2, 2, 8.5m },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2, 2, 8.5m },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 2, 2, 8.5m },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, 2, 8.5m },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 2, 2, 8.5m },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 2, 2, 8.5m },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 2, 2, 8.5m },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 2, 2, 8.5m },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 2, 2, 8.5m },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 2, 2, 8.5m },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 2, 2, 8.5m },
                    { 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 2, 2, 8.5m },
                    { 14, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, 2, 8.5m },
                    { 15, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2, 2, 8.5m },
                    { 16, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 2, 2, 8.5m },
                    { 17, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 2, 2, 8.5m },
                    { 18, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 2, 2, 8.5m },
                    { 19, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 2, 2, 8.5m },
                    { 20, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 2, 2, 8.5m },
                    { 21, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 2, 2, 8.5m },
                    { 22, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 2, 2, 8.5m },
                    { 23, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 2, 2, 8.5m },
                    { 24, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 2, 2, 8.5m },
                    { 25, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 2, 2, 8.5m },
                    { 26, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 2, 2, 8.5m },
                    { 27, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 2, 2, 8.5m },
                    { 28, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 2, 2, 8.5m },
                    { 29, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 2, 2, 8.5m },
                    { 30, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 2, 2, 8.5m },
                    { 31, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 2, 2, 8.5m },
                    { 32, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 2, 2, 8.5m },
                    { 33, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 2, 2, 8.5m },
                    { 34, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 2, 2, 8.5m },
                    { 35, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 2, 2, 8.5m },
                    { 36, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 2, 2, 8.5m },
                    { 37, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 2, 2, 8.5m },
                    { 38, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 2, 2, 8.5m },
                    { 39, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 2, 2, 8.5m },
                    { 40, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2, 2, 8.5m },
                    { 41, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 2, 2, 8.5m },
                    { 42, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 2, 2, 8.5m },
                    { 43, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 2, 2, 8.5m },
                    { 44, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 2, 2, 8.5m },
                    { 45, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 2, 2, 8.5m },
                    { 46, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 2, 2, 8.5m },
                    { 47, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 2, 2, 8.5m },
                    { 48, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 2, 2, 8.5m },
                    { 49, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 2, 2, 8.5m },
                    { 50, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 2, 2, 8.5m },
                    { 51, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, 2, 2, 8.5m },
                    { 52, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 2, 2, 8.5m },
                    { 53, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, 2, 2, 8.5m },
                    { 54, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 2, 2, 8.5m },
                    { 55, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 2, 2, 8.5m },
                    { 56, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 2, 2, 8.5m },
                    { 57, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 2, 2, 8.5m },
                    { 58, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 2, 2, 8.5m },
                    { 59, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 2, 2, 8.5m },
                    { 60, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 2, 2, 8.5m },
                    { 61, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 2, 2, 8.5m },
                    { 62, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 2, 2, 8.5m },
                    { 63, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 2, 2, 8.5m },
                    { 64, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 2, 2, 8.5m },
                    { 65, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 2, 2, 8.5m },
                    { 66, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 2, 2, 8.5m },
                    { 67, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 2, 2, 8.5m },
                    { 68, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 2, 2, 8.5m },
                    { 69, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 2, 2, 8.5m },
                    { 70, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 2, 2, 8.5m },
                    { 71, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 2, 2, 8.5m },
                    { 72, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 2, 2, 8.5m },
                    { 73, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 2, 2, 8.5m },
                    { 74, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 2, 2, 8.5m },
                    { 75, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 2, 2, 8.5m },
                    { 76, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 2, 2, 8.5m },
                    { 77, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 2, 2, 8.5m },
                    { 78, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 2, 2, 8.5m },
                    { 79, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 2, 2, 8.5m },
                    { 80, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 2, 2, 8.5m },
                    { 81, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 2, 2, 8.5m },
                    { 82, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 2, 2, 8.5m },
                    { 83, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 2, 2, 8.5m },
                    { 84, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 2, 2, 8.5m },
                    { 85, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 2, 2, 8.5m },
                    { 86, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 2, 2, 8.5m },
                    { 87, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 2, 2, 8.5m },
                    { 88, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 2, 2, 8.5m },
                    { 89, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 2, 2, 8.5m },
                    { 90, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 2, 2, 8.5m },
                    { 91, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 2, 2, 8.5m },
                    { 92, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 2, 2, 8.5m },
                    { 93, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 2, 2, 8.5m },
                    { 94, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 2, 2, 8.5m },
                    { 95, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 2, 2, 8.5m },
                    { 96, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 2, 2, 8.5m },
                    { 97, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 2, 2, 8.5m },
                    { 98, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 2, 2, 8.5m },
                    { 99, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 2, 2, 8.5m },
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 2, 2, 8.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendance_ScheduleId",
                table: "attendance",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_StudentId",
                table: "attendance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_class_TeacherId",
                table: "class",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_exam_ClassId",
                table: "exam",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_exam_RoomId",
                table: "exam",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_exam_SubjectId",
                table: "exam",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_exam_TeacherId",
                table: "exam",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_exam_TermId",
                table: "exam",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_ClassId",
                table: "schedule",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_RoomId",
                table: "schedule",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_SubjectId",
                table: "schedule",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_TeacherId",
                table: "schedule",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_TermId",
                table: "schedule",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_score_StudentId",
                table: "score",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_score_SubjectId",
                table: "score",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_score_TermId",
                table: "score",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ClassId",
                table: "user",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_schedule_ScheduleId",
                table: "attendance",
                column: "ScheduleId",
                principalTable: "schedule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_user_StudentId",
                table: "attendance",
                column: "StudentId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_class_user_TeacherId",
                table: "class",
                column: "TeacherId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_class_user_TeacherId",
                table: "class");

            migrationBuilder.DropTable(
                name: "attendance");

            migrationBuilder.DropTable(
                name: "exam");

            migrationBuilder.DropTable(
                name: "score");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "term");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "class");
        }
    }
}

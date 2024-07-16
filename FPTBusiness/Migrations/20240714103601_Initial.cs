using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FPTBusiness.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<decimal>(type: "money", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "StudentCode", "StudentName" },
                values: new object[,]
                {
                    { 1, "DE170526", "Dương Đức Anh" },
                    { 2, "DE180229", "Phan Thành Chung" },
                    { 4, "DE180391", "Hoàng Công Minh" },
                    { 5, "DE170523", "Ngô Đông Quân" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[,]
                {
                    { 1, ".NET" },
                    { 2, "JAVA" },
                    { 3, "NODEJS" },
                    { 4, "ANDROID" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "DateCreate", "Point", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 14, 17, 36, 0, 689, DateTimeKind.Local).AddTicks(4592), 6m, 1, 1 },
                    { 2, new DateTime(2024, 7, 14, 17, 36, 0, 689, DateTimeKind.Local).AddTicks(4632), 6m, 2, 2 },
                    { 3, new DateTime(2024, 7, 14, 17, 36, 0, 689, DateTimeKind.Local).AddTicks(4636), 5m, 2, 1 },
                    { 4, new DateTime(2024, 7, 14, 17, 36, 0, 689, DateTimeKind.Local).AddTicks(4640), 7m, 4, 4 },
                    { 5, new DateTime(2024, 7, 14, 17, 36, 0, 689, DateTimeKind.Local).AddTicks(4644), 7m, 5, 4 },
                    { 6, new DateTime(2024, 7, 14, 17, 36, 0, 689, DateTimeKind.Local).AddTicks(4648), 9m, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}

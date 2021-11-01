using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class update_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), 0, 1, "C#Group" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 2, 2, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), 1, 2, "JavaGroup" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 3, 3, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), 0, 3, "Web DesignGroup" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Comment", "CourseId", "GroupId", "NameLesson", "TopicLesson" },
                values: new object[,]
                {
                    { 1, "Topic 1 - lesson 1", 1, 1, "Lesson 1", "C#Topic 1" },
                    { 2, "Topic 2 - lesson 2", 1, 1, "Lesson 2", "C#Topic 2" },
                    { 3, "Topic 3 - lesson 3", 1, 1, "Lesson 3", "C#Topic 3" },
                    { 4, "Topic 1 - lesson 1", 2, 1, "Lesson 1", "JavaTopic 1" },
                    { 5, "Topic 2 - lesson 2", 2, 1, "Lesson 2", "JavaTopic 2" },
                    { 6, "Topic 3 - lesson 3", 2, 1, "Lesson 3", "JavaTopic 3" },
                    { 7, "Topic 1 - lesson 1", 3, 1, "Lesson 1", "Web DesignTopic 1" },
                    { 8, "Topic 2 - lesson 2", 3, 1, "Lesson 2", "Web DesignTopic 2" },
                    { 9, "Topic 3 - lesson 3", 3, 1, "Lesson 3", "Web DesignTopic 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

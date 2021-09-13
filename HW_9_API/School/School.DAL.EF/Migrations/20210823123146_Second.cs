using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "GroupId", "LastName", "Phone", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, null, null, "Oleg", null, "Fedorov", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, null, null, "Andrey", null, "Antonov", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, null, null, "Ivan", null, "Petrov", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 4, null, null, "Sergey", null, "Ivashko", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Bio", "BirthDate", "Email", "FirstName", "LastName", "LinkToProfile", "Phone" },
                values: new object[,]
                {
                    { 1, null, null, null, "Vadim", "Korotkov", "https://www.linkedin.com/feed/", null },
                    { 2, null, null, null, "Sergey", "Gromov", "https://www.linkedin.com/feed/", null }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, ".Net (ASP.NET, Unity)", null, ".Net" },
                    { 2, "Full-stack, JS, Spring", null, "Java" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[,]
                {
                    { 10, "Introduction to C#", "1. Getting Started", "Introduction to C#", 1 },
                    { 12, "Web with ASP.NET", "1. Controllers and MVC", "ASP.NET", 1 },
                    { 13, "Unity Game Development", "1. What is Unity", "Unity", 1 },
                    { 11, "Introduction to Java", "1. Getting Started", "Introduction to Java", 2 }
                });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 1, 10, null, 0, 1, "ASPNET_21_1" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 2, 11, null, 0, 1, "Java_23_4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

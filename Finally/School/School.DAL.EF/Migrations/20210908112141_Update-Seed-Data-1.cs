using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class UpdateSeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Bio", "BirthDate", "Email", "FirstName", "LastName", "LinkToProfile", "Phone" },
                values: new object[,]
                {
                    { 1, "My name is Vadim.", new DateTime(1977, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korotkov@mail.ru", "Vadim", "Korotkov", "https://www.linkedin.com/feed/", "+375292929292" },
                    { 2, "My name is Sergey.", new DateTime(1944, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gromov@yandex.ru", "Sergey", "Gromov", "https://www.linkedin.com/feed/", "+37533333333" }
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
                values: new object[] { 1, 10, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "ASPNET_21_1" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 2, 11, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Java_23_4" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "GroupId", "LastName", "Phone", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fedorov@gmail.com", "Oleg", 1, "Fedorov", "+3752912312323", new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 3, new DateTime(1988, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petrov@gmail.com", "Ivan", 1, "Petrov", "+375445765647", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonov@gmail.com", "Andrey", 2, "Antonov", "+37529111111", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivashko@gmail.com", "Sergey", 2, "Ivashko", "+375444444444", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }
    }
}

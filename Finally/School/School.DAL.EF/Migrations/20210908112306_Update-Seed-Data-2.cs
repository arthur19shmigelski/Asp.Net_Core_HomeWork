using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class UpdateSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Bio", "BirthDate", "Email", "FirstName", "LastName", "LinkToProfile", "Phone" },
                values: new object[,]
                {
                    { 1, "My name is Vadim Korotkov.", new DateTime(1977, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korotkov@mail.ru", "Vadim", "Korotkov", "https://www.linkedin.com/feed/Korotkov", "+375291111111" },
                    { 2, "My name is Sergey Gromov.", new DateTime(1944, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gromov@yandex.ru", "Sergey", "Gromov", "https://www.linkedin.com/feed/Gromov", "+375292222222" },
                    { 3, "My name is Andrew Kamilov.", new DateTime(1956, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamilov@yandex.ru", "Andrew", "Kamilov", "https://www.linkedin.com/feed/Kamilov", "+375293333333" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, ".Net (ASP.NET, Unity)", null, ".Net" },
                    { 2, "Full-stack, JS, Spring", null, "Java" },
                    { 3, "UI/UX, Motion Design, 3D Design", null, "Design" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[] { 1, "Introduction to C#", "1. Getting Started", "Introduction to C#", 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[] { 2, "Introduction to Java", "1. Getting Started", "Introduction to Java", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[] { 3, "Web with Motion Design", "1. What is Motion Design?", "Web Design", 3 });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 1, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "Basic_C#_01.01" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 2, 2, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, "Java_02_02" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 3, 3, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, "Motion Design_03_03" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "GroupId", "LastName", "Phone", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fedorov@gmail.com", "Oleg", 1, "Fedorov", "+375291111111", new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 4, new DateTime(2000, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivashko@gmail.com", "Sergey", 1, "Ivashko", "+375444444444", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 7, new DateTime(1994, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micinat@gmail.com", "Vladimir", 1, "Micinat", "+375447777777", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(1999, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "YakimovMiron@gmail.com", "Miron", 1, "Yakimov", "+375441010101", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2000, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "FistashkaIrina@yandex.by", "Irina", 1, "Fistashka", "+375444444444", new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonov@gmail.com", "Andrey", 2, "Antonov", "+375292222222", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(1998, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shmigelski@gmail.com", "Arthur", 2, "Shmigelski", "+375295555555", new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 8, new DateTime(1973, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frunze@mail.ru", "Anatoliy", 2, "Frunze", "+375448888888", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(1999, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "MorozNikita@gmail.com", "Nikita", 2, "Moroz", "+375440110111", new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2000, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivashko@gmail.com", "Alena", 2, "Filimonova", "+375441534545", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(1988, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petrov@gmail.com", "Ivan", 3, "Petrov", "+375443333333", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(1997, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergeenko@yandex.com", "Maxim", 3, "Sergeenko", "+375446666666", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(1992, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "VaneevaPolina@gmail.com", "Polina", 3, "Vaneeva", "+375449999999", new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(1996, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PonimashVitalik@gmail.com", "Vitalik", 3, "Ponimash", "+375441212123", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 15, new DateTime(1988, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "EfremovSergey@mail.ru", "Sergey", 3, "Efremov", "+375441232323", new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class Add_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StartDate", "Status" },
                values: new object[] { new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate" },
                values: new object[] { new DateTime(1998, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "+3752912312323", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate", "Type" },
                values: new object[] { new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "+37529111111", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate", "Type" },
                values: new object[] { new DateTime(1988, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "+375445765647", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "+375444444444", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "BirthDate", "Email", "Phone" },
                values: new object[] { "My name is Vadim.", new DateTime(1977, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korotkov@mail.ru", "+375292929292" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "BirthDate", "Email", "Phone" },
                values: new object[] { "My name is Sergey.", new DateTime(1944, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gromov@yandex.ru", "+37533333333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StartDate", "Status" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate", "Type" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate", "Type" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "BirthDate", "Email", "Phone" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "BirthDate", "Email", "Phone" },
                values: new object[] { null, null, null, null });
        }
    }
}

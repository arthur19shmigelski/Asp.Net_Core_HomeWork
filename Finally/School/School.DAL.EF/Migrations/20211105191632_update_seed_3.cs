using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class update_seed_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StartDate", "Title" },
                values: new object[] { new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), "C# Group" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StartDate", "Status", "Title" },
                values: new object[] { new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), 0, "Java Group" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "StartDate", "Title" },
                values: new object[] { new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), "Web Design Group" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "StartDate", "Status", "Title" },
                values: new object[] { new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), 0, "Промышленная разработка ПО на ASP.NET Group" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "StartDate", "Title" },
                values: new object[] { new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), "Промышленная разработка ПО на Java Group" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StartDate", "Title" },
                values: new object[] { new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "C#Group" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StartDate", "Status", "Title" },
                values: new object[] { new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, "JavaGroup" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "StartDate", "Title" },
                values: new object[] { new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "Web DesignGroup" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "StartDate", "Status", "Title" },
                values: new object[] { new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, "Промышленная разработка ПО на ASP.NETGroup" });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "StartDate", "Title" },
                values: new object[] { new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "Промышленная разработка ПО на JavaGroup" });
        }
    }
}

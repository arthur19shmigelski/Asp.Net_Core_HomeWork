using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class Update_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationWeeks",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Courses",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "DurationWeeks", "Price" },
                values: new object[] { ".NET разработчик создаёт приложения, игры на языке программирования C# на платформе .NET, которую поддерживает Microsoft.	Курс поможет с нуля освоить востребованную специальность .NET-разработчика", 8, 1350.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "DurationWeeks", "Price" },
                values: new object[] { "Курс поможет с нуля освоить востребованную специальность Java-разработчика. 	Программа построена таким образом, что вы не просто познакомитесь с основами Java и объектно-ориентированным программированием на нем, 	а научитесь разбираться в типах данных, использовать алгоритмы и коллекции Java. ", 8, 1420.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DurationWeeks", "Price" },
                values: new object[] { "Современный дизайн — обширная область, которая тесно соприкасается с ИТ-сферой, а UX/UI-дизайнеры, веб-дизайнеры и дизайнеры интерфейсов — одновременно и художники, и технически подкованные специалисты, востребованные в индустрии.	 Курс поможет с нуля освоить востребованную специальность Design-разработчика", 6, 1250.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "DurationWeeks", "Level", "Price" },
                values: new object[] { "ASP.NET разработчик создаёт приложения и игры на языке программирования C# на платформе .NET, которую поддерживает Microsoft.", 10, 1, 1610.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "DurationWeeks", "Level", "Price" },
                values: new object[] { "Курс подойдет как студентам технических ВУЗов и специалистам, которым интересно освоить новый язык, так и новичкам в программировании. Но для зачисления необходимо будет сдать тесты по логике и английскому языку.", 10, 1, 1650.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DurationWeeks", "Level", "Price" },
                values: new object[] { 8, 1, 1440.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "DurationWeeks", "Level", "Price" },
                values: new object[] { "Unity - это современный и мощный игровой движок, позволяющий делать игры любого уровня.	Unity-разработчик создаёт игры и приложения почти под все игровые платформы.", 14, 2, 2040.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "DurationWeeks", "Level", "Price" },
                values: new object[] { "В одном супер-курсе мы собрали не только все главные технологии с двух сторон (Front-end и Back-end), которые сегодня активно используются в разработке веб-приложений: HTML, CSS, JavaScript, PHP, SQL; но и изучение основ веб-дизайна, общих принципов клиент-серверной архитектуры веб-приложений, ООП, фреймворков ReactJs и Laravel, системы контроля версий Git и сервиса GitHub.", 15, 2, 2570.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "DurationWeeks", "Level", "Price" },
                values: new object[] { "Этот курс Angular, React, Vue для тех, кто хочет стать программистом и работать в сфере веб-разработки. 2,5 месяца теории и практического опыта.", 12, 2, 2300.0 });

            migrationBuilder.UpdateData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 8,
                column: "StudentId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 9,
                column: "StudentId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 10,
                column: "StudentId",
                value: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationWeeks",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Базовый уровень");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Базовый уровень");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Базовый уровень");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Средний уровень");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Средний уровень");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Высокий уровень");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Высокий уровень");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Высокий уровень");

            migrationBuilder.UpdateData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 8,
                column: "StudentId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 9,
                column: "StudentId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 10,
                column: "StudentId",
                value: 9);
        }
    }
}

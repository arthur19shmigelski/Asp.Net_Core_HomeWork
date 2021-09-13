using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class Update_Seed_Data_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Program" },
                values: new object[] { "	C# (си шарп) – объектно-ориентированный язык программирования, разработанный компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он продолжит развиваться и находить применение в различных отраслях.\n	C Sharp впитал лучшие качества, а также унаследовал особенности синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET.", "1. Вводное. Установка окружения(C#, Visual Studio). Запуск первой программы Console Application.2. Типы данных. Переменные. Операторы.3. Операторы if/switch4. Циклы5. И многое другое" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Program" },
                values: new object[] { "Язык программирования Java находится в числе лидеров во многих рейтингах: TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google, IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность обусловлена практически безграничными его возможностями и областями применения. Java не зависит от определённой платформы, его называют безопасным, портативным, высокопроизводительным и динамичным языком.", "1. Вводное. Установка окружения(Java, Intellij IDEA). Запуск первой программы.2. Типы данных. Переменные. Операторы.3. Операторы if/switch4. Циклы5. И многое другое" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Program" },
                values: new object[] { "UI/UX и web-дизайн ориентирован на создание внешне привлекательных, удобных в использовании и функциональных пользовательских интерфейсов. Чтобы достичь успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами (например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).", "1. Принципы визуального дизайна2. Особенности UI/UX/web дизайна3. Основы композиции4. Правила работы со шрифтамин5. И много другой информации" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                column: "Email",
                value: "Filimonova@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Program" },
                values: new object[] { "Introduction to C#", "1. Getting Started" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Program" },
                values: new object[] { "Introduction to Java", "1. Getting Started" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Program" },
                values: new object[] { "Web with Motion Design", "1. What is Motion Design?" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                column: "Email",
                value: "Ivashko@gmail.com");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class Update_seed_data_1 : Migration
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

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadyToStartDate",
                table: "StudentRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, "Базовый уровень", "1. Вводное. Установка окружения(C#, Visual Studio). Запуск первой программы Console Application.\n2. Типы данных. Переменные. Операторы.\n3. Операторы if/switch.\n4. Циклы.\n5. И многое другое...", "C#", 1 },
                    { 2, "Базовый уровень", "1. Вводное. Установка окружения(Java, Intellij IDEA). Запуск первой программы.\n2. Типы данных. Переменные. Операторы.\n3. Операторы if/switch.\n4. Циклы.\n5. И многое другое...", "Java", 2 },
                    { 4, "Средний уровень", "1. Основы MVC: -Паттерн MVC, MVC контроллеры, разработка представлений.\n2. Основы WebApi: -Архитектура REST; -Проектирование RESTful сервисов, Self-Hosted приложения\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики; -DI и паттерн IoC\n4. Работа с данными: -Понятие ORM, Entity Framework; -Основные подходы к проектированию БД: CodeFirst, DatabaseFirst, ModelFirst\n5. И многое другое...", "Промышленная разработка ПО на ASP.NET", 1 },
                    { 5, "Средний уровень", "1. Основы Apache Maven.\n2. Инженерные техники при работе с Apache Maven.\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики, паттерн DAO; -Практика.\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL.\n5. И многое другое...", "Промышленная разработка ПО на Java", 2 },
                    { 7, "Высокий уровень", "1. Введение в Unity. Hello world с Unity.\n2. Scripts (Cкрипты). Part 1: -Методология; -Игровые объекты и компоненты; -Cлои, ввод данных, теги.\n3. Scripts (Скрипты). Part 2: -Manual: Immediate Mode GUI (IMGUI); -Сопрограммы.\n4. Инструментарий для разработки 2D-игр.\n5. И многое другое...", "Unity", 1 },
                    { 8, "Высокий уровень", "1. JQuery.\n2. EscmaScript6.\n3. Расширенные возможность JavaScript\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL\n5. И многое другое...", "Full-stack developer", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "GroupId", "Phone" },
                values: new object[] { 22, null, "+375291111111" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "GroupId", "Phone" },
                values: new object[] { 26, null, "+375292222222" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "GroupId", "Phone" },
                values: new object[] { 17, null, "+375443333333" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Age", "GroupId" },
                values: new object[] { 19, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Email", "FirstName", "GroupId", "LastName", "Phone", "Type" },
                values: new object[,]
                {
                    { 15, 25, "EfremovSergey@mail.ru", "Sergey", null, "Efremov", "+375441232323", 0 },
                    { 14, 20, "Filimonova@gmail.com", "Alena", null, "Filimonova", "+375441534545", 2 },
                    { 12, 25, "PonimashVitalik@gmail.com", "Vitalik", null, "Ponimash", "+375441212123", 0 },
                    { 13, 29, "FistashkaIrina@yandex.by", "Irina", null, "Fistashka", "+375444444444", 0 },
                    { 10, 39, "YakimovMiron@gmail.com", "Miron", null, "Yakimov", "+375441010101", 1 },
                    { 9, 40, "VaneevaPolina@gmail.com", "Polina", null, "Vaneeva", "+375449999999", 2 },
                    { 8, 46, "Frunze@mail.ru", "Anatoliy", null, "Frunze", "+375448888888", 1 },
                    { 7, 50, "Micinat@gmail.com", "Vladimir", null, "Micinat", "+375447777777", 2 },
                    { 6, 25, "Sergeenko@yandex.com", "Maxim", null, "Sergeenko", "+375446666666", 2 },
                    { 5, 25, "Shmigelski@gmail.com", "Arthur", null, "Shmigelski", "+375295555555", 0 },
                    { 11, 22, "MorozNikita@gmail.com", "Nikita", null, "Moroz", "+375440110111", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Bio", "LinkToProfile", "Phone" },
                values: new object[] { 30, "My name is Vadim Korotkov. I'am full-stack developer. I know all language, frameworks", "https://www.linkedin.com/feed/Korotkov", "+375291111111" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Bio", "LinkToProfile", "Phone" },
                values: new object[] { 32, "My name is Sergey Gromov. I'am a back-end developer on .Net Framework + Java (JS).", "https://www.linkedin.com/feed/Gromov", "+375292222222" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "Bio", "Email", "FirstName", "LastName", "LinkToProfile", "Phone" },
                values: new object[,]
                {
                    { 3, 36, "My name is Andrew Kamilov. I'am front-end developer, know some modern frameworks (Angular, Vue, React)", "Kamilov@yandex.ru", "Andrew", "Kamilov", "https://www.linkedin.com/feed/Kamilov", "+375293333333" },
                    { 4, 34, "My name is Marina Kuzmina. I am a Design teacher", "Kuzmina@yandex.ru", "Marina", "Kuzmina", "https://www.linkedin.com/feed/Kuzmina", "+375296561723" },
                    { 5, 27, "My name is Vladimir Vorobei. I am a C# language teacher", "Vorobei@yandex.ru", "Vladimir", "Vorobei", "https://www.linkedin.com/feed/Vorobei", "+375290989093" }
                });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "	C# (си шарп) – объектно-ориентированный язык программирования, разработанный компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он продолжит развиваться и находить применение в различных отраслях.\n	C Sharp впитал лучшие качества, а также унаследовал особенности синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET.");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "	Язык программирования Java находится в числе лидеров во многих рейтингах: TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google, IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность обусловлена практически безграничными его возможностями и областями применения.\n	Java не зависит от определённой платформы, его называют безопасным, портативным, высокопроизводительным и динамичным языком.");

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "ParentId", "Title" },
                values: new object[] { 3, "	UI/UX и web-дизайн ориентирован на создание внешне привлекательных, удобных в использовании и функциональных пользовательских интерфейсов. Чтобы достичь успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами (например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).", null, "Design" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[,]
                {
                    { 3, "Базовый уровень", "1. Принципы визуального дизайна.\n2. Особенности UI/UX/web дизайна.\n3. Основы композиции.\n4. Правила работы со шрифтами.\n5. И многое другое...", "Web Design", 3 },
                    { 6, "Средний уровень", "1. Знакомство с библиотекой React.\n2. Настройка Git и Webpack.\n3. Глубокое изучение JavaScript.\n4. Твоя первая большая курсовая работа в команде (простой суши-магазин).\n5. И многое другое...", "Веб-разработка на языках HTML, CSS и JavaScript ", 3 },
                    { 9, "Высокий уровень", "1. Знакомство с библиотекой React\n2.Знакомство с библиотекой Angular\n3. Знакомство с библиотекой Vue\n4. Твоя первая большая курсовая работа в команде (3 проекта на каждом фрэймворке - магазин доставки цветов)\n5. И многое другое...", "Angular, React, Vue", 3 }
                });

            migrationBuilder.InsertData(
                table: "StudentRequests",
                columns: new[] { "Id", "Comments", "CourseId", "Created", "ReadyToStartDate", "Status", "StudentId", "Updated" },
                values: new object[,]
                {
                    { 1, "Хочу учиться на C# (basic) ", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null },
                    { 2, "Хочу учиться на C# (basic)", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, null },
                    { 3, "Хочу учиться на Java (basic)", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, null },
                    { 4, "Хочу учиться на Java (basic)", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, null },
                    { 7, "Хочу учиться на C# (средний)", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, null },
                    { 8, "Хочу учиться на С# (средний)", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, null },
                    { 9, "Хочу учиться на Java (средний)", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 8, null },
                    { 10, "Хочу учиться на Java (средний)", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 9, null }
                });

            migrationBuilder.InsertData(
                table: "StudentRequests",
                columns: new[] { "Id", "Comments", "CourseId", "Created", "ReadyToStartDate", "Status", "StudentId", "Updated" },
                values: new object[] { 5, "Хочу учиться на Design (basic)", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, null });

            migrationBuilder.InsertData(
                table: "StudentRequests",
                columns: new[] { "Id", "Comments", "CourseId", "Created", "ReadyToStartDate", "Status", "StudentId", "Updated" },
                values: new object[] { 6, "Хочу учиться на Design (basic)", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 6, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 10);

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
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5);

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
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

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
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ReadyToStartDate",
                table: "StudentRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Teachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[,]
                {
                    { 10, "Introduction to C#", "1. Getting Started", "Introduction to C#", 1 },
                    { 11, "Introduction to Java", "1. Getting Started", "Introduction to Java", 2 },
                    { 12, "Web with ASP.NET", "1. Controllers and MVC", "ASP.NET", 1 },
                    { 13, "Unity Game Development", "1. What is Unity", "Unity", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "BirthDate", "LinkToProfile", "Phone" },
                values: new object[] { "My name is Vadim.", new DateTime(1977, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.linkedin.com/feed/", "+375292929292" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "BirthDate", "LinkToProfile", "Phone" },
                values: new object[] { "My name is Sergey.", new DateTime(1944, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.linkedin.com/feed/", "+37533333333" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: ".Net (ASP.NET, Unity)");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Full-stack, JS, Spring");

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 1, 10, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "ASPNET_21_1" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[] { 2, 11, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Java_23_4" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate" },
                values: new object[] { new DateTime(1998, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "+3752912312323", new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate" },
                values: new object[] { new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "+37529111111", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "GroupId", "Phone", "StartDate" },
                values: new object[] { new DateTime(1988, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "+375445765647", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "GroupId", "StartDate" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class update_seed_data_02112021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Курс поможет с нуля освоить востребованную специальность Java-разработчика. 	Программа построена таким образом, что вы не просто познакомитесь с основами Java и объектно-ориентированным программированием на нем, 	научитесь разбираться в типах данных, использовать алгоритмы и коллекции Java. ");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Современный дизайн — обширная область, которая тесно соприкасается с ИТ-сферой, а UX/UI-дизайнеры, веб-дизайнеры и дизайнеры интерфейсов — одновременно и художники, и технически подкованные специалисты, востребованные в индустрии.\n	Курс поможет с нуля освоить востребованную специальность Design-разработчика");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Курс рассчитан на подготовку рекрутеров, работающих в отраслях IT, IOT, R&D и высокотехнологичного производства.За годы существования программа постоянно совершенствовалась. Сейчас в ней выдержан баланс теории и практики, остались только темы и занятия, непосредственно связанные с работой ИТ-рекрутера.\n	Благодаря практическим заданиям, моделирующим работу ИТ-рекрутера, за 4 недели ученики успевают полностью овладеть профессиональными инструментами рекрутера и могут приступать к работе уже во время обучения.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент.IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам.\n	Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Поиск сотрудников на открытые вакансии, помощь в адаптации новым коллегам, работа с коллективом, развитие корпоративной культуры...\n	Задач в сфере HR сегодня много. Как во всем разобраться и понять специфику работы в IT? Решить эти вопросы поможет данный курс.\n	После обучения вы будете понимать, подходит ли вам работа HR в IT, а также то, в какой компании хотите работать и чем можете быть ей полезны. Выпускники смогут претендовать на позицию associate/junior HR. Средняя зарплата у опытных специалистов в этой сфере – свыше 1300 долларов.");

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), 1, 4, "Промышленная разработка ПО на ASP.NETGroup" },
                    { 5, 5, new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), 0, 5, "Промышленная разработка ПО на JavaGroup" }
                });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "	UI/UX и web-дизайн ориентирован на создание внешне привлекательных, удобных в использовании и функциональных пользовательских интерфейсов.\n	Чтобы достичь успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами (например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "	Зачастую можно услышать вопрос, что такое HR-менеджер, как переводится и чем занимается специалист. Если посмотреть должностную инструкцию, становится понятно, что он разрабатывает систему управления персоналом, расставляет приоритеты, развивает сотрудников, прорисовывает цели для них. Помимо этого HR мотивирует, оценивает и ищет нужных специалистов.	\nС помощью данного направления вы уверитесь в значимости HR-менеджера в IT-компании и узнаете обо всех тонкостях профессии как в теории, так и на практике");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Курс поможет с нуля освоить востребованную специальность Java-разработчика. 	Программа построена таким образом, что вы не просто познакомитесь с основами Java и объектно-ориентированным программированием на нем, 	а научитесь разбираться в типах данных, использовать алгоритмы и коллекции Java. ");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Современный дизайн — обширная область, которая тесно соприкасается с ИТ-сферой, а UX/UI-дизайнеры, веб-дизайнеры и дизайнеры интерфейсов — одновременно и художники, и технически подкованные специалисты, востребованные в индустрии.	 Курс поможет с нуля освоить востребованную специальность Design-разработчика");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Курс рассчитан на подготовку рекрутеров, работающих в отраслях IT, IOT, R&D и высокотехнологичного производства.Курс рассчитан на подготовку рекрутеров, работающих в отраслях IT, IOT, R&D и высокотехнологичного производства.За годы существования программа постоянно совершенствовалась. Сейчас в ней выдержан баланс теории и практики, остались только темы и занятия, непосредственно связанные с работой ИТ-рекрутера.Благодаря практическим заданиям, моделирующим работу ИТ-рекрутера, за 4 недели ученики успевают полностью овладеть профессиональными инструментами рекрутера и могут приступать к работе уже во время обучения.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент.IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам.Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Поиск сотрудников на открытые вакансии, помощь в адаптации новым коллегам, работа с коллективом, развитие корпоративной культуры... Задач в сфере HR сегодня много. Как во всем разобраться и понять специфику работы в IT? Решить эти вопросы поможет данный курс.После обучения вы будете понимать, подходит ли вам работа HR в IT, а также то, в какой компании хотите работать и чем можете быть ей полезны. Выпускники смогут претендовать на позицию associate/junior HR. Средняя зарплата у опытных специалистов в этой сфере – свыше 1300 долларов.");

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Comment", "CourseId", "GroupId", "NameLesson", "TopicLesson" },
                values: new object[,]
                {
                    { 9, "Topic 3 - lesson 3", 3, 1, "Lesson 3", "Web DesignTopic 3" },
                    { 8, "Topic 2 - lesson 2", 3, 1, "Lesson 2", "Web DesignTopic 2" },
                    { 1, "Topic 1 - lesson 1", 1, 1, "Lesson 1", "C#Topic 1" },
                    { 6, "Topic 3 - lesson 3", 2, 1, "Lesson 3", "JavaTopic 3" },
                    { 5, "Topic 2 - lesson 2", 2, 1, "Lesson 2", "JavaTopic 2" },
                    { 4, "Topic 1 - lesson 1", 2, 1, "Lesson 1", "JavaTopic 1" },
                    { 3, "Topic 3 - lesson 3", 1, 1, "Lesson 3", "C#Topic 3" },
                    { 2, "Topic 2 - lesson 2", 1, 1, "Lesson 2", "C#Topic 2" },
                    { 7, "Topic 1 - lesson 1", 3, 1, "Lesson 1", "Web DesignTopic 1" }
                });

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "StudentGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "	UI/UX и web-дизайн ориентирован на создание внешне привлекательных, удобных в использовании и функциональных пользовательских интерфейсов. Чтобы достичь успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами (например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "	Зачастую можно услышать вопрос, что такое HR-менеджер, как переводится и чем занимается специалист. Если посмотреть должностную инструкцию, становится понятно, что он разрабатывает систему управления персоналом, расставляет приоритеты, развивает сотрудников, прорисовывает цели для них. Помимо этого HR мотивирует, оценивает и ищет нужных специалистов.	\n С помощью данного направления вы уверитесь в значимости HR-менеджера в IT-компании и узнаете обо всех тонкостях профессии как в теории, так и на практике");
        }
    }
}

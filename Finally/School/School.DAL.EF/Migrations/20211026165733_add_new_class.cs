using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class add_new_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicLessons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLessons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_StudentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "StudentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Курс рассчитан на подготовку рекрутеров, работающих в отраслях IT, IOT, R&D и высокотехнологичного производства.Курс рассчитан на подготовку рекрутеров, работающих в отраслях IT, IOT, R&D и высокотехнологичного производства.За годы существования программа постоянно совершенствовалась. Сейчас в ней выдержан баланс теории и практики, остались только темы и занятия, непосредственно связанные с работой ИТ-рекрутера.Благодаря практическим заданиям, моделирующим работу ИТ-рекрутера, за 4 недели ученики успевают полностью овладеть профессиональными инструментами рекрутера и могут приступать к работе уже во время обучения.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Поиск сотрудников на открытые вакансии, помощь в адаптации новым коллегам, работа с коллективом, развитие корпоративной культуры... Задач в сфере HR сегодня много. Как во всем разобраться и понять специфику работы в IT? Решить эти вопросы поможет данный курс.После обучения вы будете понимать, подходит ли вам работа HR в IT, а также то, в какой компании хотите работать и чем можете быть ей полезны. Выпускники смогут претендовать на позицию associate/junior HR. Средняя зарплата у опытных специалистов в этой сфере – свыше 1300 долларов.");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupId",
                table: "Lessons",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент.IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам.Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент.IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам.Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.");
        }
    }
}

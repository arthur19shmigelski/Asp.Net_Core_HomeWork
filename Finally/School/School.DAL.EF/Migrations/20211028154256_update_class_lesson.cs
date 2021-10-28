using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class update_class_lesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_StudentGroups_GroupId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Topics_TopicId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TopicId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "TopicLessons",
                table: "Lessons",
                newName: "TopicLesson");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Lessons",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "NameLessons",
                table: "Lessons",
                newName: "NameLesson");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_StudentGroups_GroupId",
                table: "Lessons",
                column: "GroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_StudentGroups_GroupId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "TopicLesson",
                table: "Lessons",
                newName: "TopicLessons");

            migrationBuilder.RenameColumn(
                name: "NameLesson",
                table: "Lessons",
                newName: "NameLessons");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lessons",
                newName: "TopicId");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Lessons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TopicId",
                table: "Lessons",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_StudentGroups_GroupId",
                table: "Lessons",
                column: "GroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Topics_TopicId",
                table: "Lessons",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class uptade_class_lesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lessons",
                newName: "TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                newName: "IX_Lessons_TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Topics_TopicId",
                table: "Lessons",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Topics_TopicId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Lessons",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_TopicId",
                table: "Lessons",
                newName: "IX_Lessons_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

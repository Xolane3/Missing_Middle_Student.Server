using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Missing_Middle_Student.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToStudentNum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNum",
                table: "Students",
                column: "StudentNum",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_StudentNum",
                table: "Students");
        }
    }
}

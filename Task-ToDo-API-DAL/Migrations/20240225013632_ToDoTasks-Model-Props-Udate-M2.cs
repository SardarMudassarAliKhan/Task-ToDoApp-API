using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_ToDo_API_DAL.Migrations
{
    /// <inheritdoc />
    public partial class ToDoTasksModelPropsUdateM2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "ToDoTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "ToDoTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDoTasks");

            migrationBuilder.DropColumn(
                name: "status",
                table: "ToDoTasks");
        }
    }
}

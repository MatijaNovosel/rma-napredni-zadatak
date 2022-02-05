using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMA_API.Migrations
{
    public partial class MarkAsDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TodoItems",
                newName: "Text");

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "TodoItems",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "TodoItems",
                newName: "Description");
        }
    }
}

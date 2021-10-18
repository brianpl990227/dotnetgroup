using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class UserBlocked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Blocked",
                table: "AppUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "AppUsers");
        }
    }
}

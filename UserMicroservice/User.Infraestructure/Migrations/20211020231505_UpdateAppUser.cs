using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class UpdateAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_FailUserLogin_FailUserLoginNavId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_FailUserLoginNavId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "FailUserLoginNavId",
                table: "AppUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailUserLoginNavId",
                table: "AppUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_FailUserLoginNavId",
                table: "AppUsers",
                column: "FailUserLoginNavId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_FailUserLogin_FailUserLoginNavId",
                table: "AppUsers",
                column: "FailUserLoginNavId",
                principalTable: "FailUserLogin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

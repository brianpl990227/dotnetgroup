using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class emailForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FailUserLogin_AppUsers_AppUserId",
                table: "FailUserLogin");

            migrationBuilder.DropIndex(
                name: "IX_FailUserLogin_AppUserId",
                table: "FailUserLogin");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "FailUserLogin");

            migrationBuilder.AddColumn<string>(
                name: "appUserEmail",
                table: "FailUserLogin",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_FailUserLogin_FailUserLoginNavId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_FailUserLoginNavId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "appUserEmail",
                table: "FailUserLogin");

            migrationBuilder.DropColumn(
                name: "FailUserLoginNavId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "FailUserLogin",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FailUserLogin_AppUserId",
                table: "FailUserLogin",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FailUserLogin_AppUsers_AppUserId",
                table: "FailUserLogin",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

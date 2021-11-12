using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMicroservice.Infraestruture.Migrations
{
    public partial class ValidationsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BlogPromo",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BlogPromo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(140)",
                oldMaxLength: 140,
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMicroservice.Infraestruture.Migrations
{
    public partial class UrlImgBlogProm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImg",
                table: "BlogPromo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImg",
                table: "BlogPromo");
        }
    }
}

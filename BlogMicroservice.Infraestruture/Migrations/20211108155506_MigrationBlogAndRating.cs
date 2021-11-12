using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMicroservice.Infraestruture.Migrations
{
    public partial class MigrationBlogAndRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingPromo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAppId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingPromo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPromo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainPrice = table.Column<int>(type: "int", nullable: false),
                    PromoPrice = table.Column<int>(type: "int", nullable: false),
                    PromoRatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPromo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPromo_RatingPromo_PromoRatingId",
                        column: x => x.PromoRatingId,
                        principalTable: "RatingPromo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPromo_PromoRatingId",
                table: "BlogPromo",
                column: "PromoRatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPromo");

            migrationBuilder.DropTable(
                name: "RatingPromo");
        }
    }
}

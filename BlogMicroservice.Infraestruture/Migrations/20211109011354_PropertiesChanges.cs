using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMicroservice.Infraestruture.Migrations
{
    public partial class PropertiesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPromo_RatingPromo_PromoRatingId",
                table: "BlogPromo");

            migrationBuilder.DropIndex(
                name: "IX_BlogPromo_PromoRatingId",
                table: "BlogPromo");

            migrationBuilder.DropColumn(
                name: "PromoRatingId",
                table: "BlogPromo");

            migrationBuilder.AlterColumn<int>(
                name: "UserAppId",
                table: "RatingPromo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BlogPromoId",
                table: "RatingPromo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RatingPromo_BlogPromoId",
                table: "RatingPromo",
                column: "BlogPromoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingPromo_BlogPromo_BlogPromoId",
                table: "RatingPromo",
                column: "BlogPromoId",
                principalTable: "BlogPromo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingPromo_BlogPromo_BlogPromoId",
                table: "RatingPromo");

            migrationBuilder.DropIndex(
                name: "IX_RatingPromo_BlogPromoId",
                table: "RatingPromo");

            migrationBuilder.DropColumn(
                name: "BlogPromoId",
                table: "RatingPromo");

            migrationBuilder.AlterColumn<int>(
                name: "UserAppId",
                table: "RatingPromo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromoRatingId",
                table: "BlogPromo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPromo_PromoRatingId",
                table: "BlogPromo",
                column: "PromoRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPromo_RatingPromo_PromoRatingId",
                table: "BlogPromo",
                column: "PromoRatingId",
                principalTable: "RatingPromo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

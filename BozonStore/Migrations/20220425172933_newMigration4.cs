using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class newMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Buyers_BuyerId",
                table: "Purchases");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Buyers_BuyerId",
                table: "Purchases",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Buyers_BuyerId",
                table: "Purchases");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Buyers_BuyerId",
                table: "Purchases",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

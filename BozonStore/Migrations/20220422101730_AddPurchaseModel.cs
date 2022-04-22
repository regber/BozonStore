using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class AddPurchaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_BaseProducts_ProductId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_SellerShop_SellerShopId",
                table: "Purchases");

            migrationBuilder.CreateTable(
                name: "PurchaseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseProducts_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasSellerShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasSellerShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasSellerShops_SellerShop_Id",
                        column: x => x.Id,
                        principalTable: "SellerShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchaseProducts_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "PurchaseProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchasSellerShops_SellerShopId",
                table: "Purchases",
                column: "SellerShopId",
                principalTable: "PurchasSellerShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseProducts_ProductId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchasSellerShops_SellerShopId",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "PurchaseProducts");

            migrationBuilder.DropTable(
                name: "PurchasSellerShops");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_BaseProducts_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "BaseProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_SellerShop_SellerShopId",
                table: "Purchases",
                column: "SellerShopId",
                principalTable: "SellerShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

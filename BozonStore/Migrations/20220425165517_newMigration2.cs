using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class newMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseImages_PurchaseProducts_PurchaseProductId",
                table: "PurchaseImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_PurchaseImages_MainImageId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_PurchasShops_PurchaseShopId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Sellers_PurchaseSellerId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseProducts_ProductId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts");

            migrationBuilder.RenameTable(
                name: "PurchaseProducts",
                newName: "PurchasProducts");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseProducts_PurchaseShopId",
                table: "PurchasProducts",
                newName: "IX_PurchasProducts_PurchaseShopId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseProducts_PurchaseSellerId",
                table: "PurchasProducts",
                newName: "IX_PurchasProducts_PurchaseSellerId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseProducts_MainImageId",
                table: "PurchasProducts",
                newName: "IX_PurchasProducts_MainImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasProducts",
                table: "PurchasProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseImages_PurchasProducts_PurchaseProductId",
                table: "PurchaseImages",
                column: "PurchaseProductId",
                principalTable: "PurchasProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchasProducts_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "PurchasProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasProducts_PurchaseImages_MainImageId",
                table: "PurchasProducts",
                column: "MainImageId",
                principalTable: "PurchaseImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasProducts_PurchasShops_PurchaseShopId",
                table: "PurchasProducts",
                column: "PurchaseShopId",
                principalTable: "PurchasShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasProducts_Sellers_PurchaseSellerId",
                table: "PurchasProducts",
                column: "PurchaseSellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseImages_PurchasProducts_PurchaseProductId",
                table: "PurchaseImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchasProducts_ProductId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasProducts_PurchaseImages_MainImageId",
                table: "PurchasProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasProducts_PurchasShops_PurchaseShopId",
                table: "PurchasProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasProducts_Sellers_PurchaseSellerId",
                table: "PurchasProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasProducts",
                table: "PurchasProducts");

            migrationBuilder.RenameTable(
                name: "PurchasProducts",
                newName: "PurchaseProducts");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasProducts_PurchaseShopId",
                table: "PurchaseProducts",
                newName: "IX_PurchaseProducts_PurchaseShopId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasProducts_PurchaseSellerId",
                table: "PurchaseProducts",
                newName: "IX_PurchaseProducts_PurchaseSellerId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasProducts_MainImageId",
                table: "PurchaseProducts",
                newName: "IX_PurchaseProducts_MainImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseImages_PurchaseProducts_PurchaseProductId",
                table: "PurchaseImages",
                column: "PurchaseProductId",
                principalTable: "PurchaseProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_PurchaseImages_MainImageId",
                table: "PurchaseProducts",
                column: "MainImageId",
                principalTable: "PurchaseImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_PurchasShops_PurchaseShopId",
                table: "PurchaseProducts",
                column: "PurchaseShopId",
                principalTable: "PurchasShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Sellers_PurchaseSellerId",
                table: "PurchaseProducts",
                column: "PurchaseSellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchaseProducts_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "PurchaseProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

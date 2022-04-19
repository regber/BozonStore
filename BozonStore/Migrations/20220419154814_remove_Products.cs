using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class remove_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_BaseProductId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Color_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Image_MainImageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SellerShop_SellerShopId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_SellerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Products_ProductId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "BaseProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerShopId",
                table: "BaseProduct",
                newName: "IX_BaseProduct_SellerShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerId",
                table: "BaseProduct",
                newName: "IX_BaseProduct_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_MainImageId",
                table: "BaseProduct",
                newName: "IX_BaseProduct_MainImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ColorId",
                table: "BaseProduct",
                newName: "IX_BaseProduct_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseProduct",
                table: "BaseProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProduct_Color_ColorId",
                table: "BaseProduct",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProduct_Image_MainImageId",
                table: "BaseProduct",
                column: "MainImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProduct_SellerShop_SellerShopId",
                table: "BaseProduct",
                column: "SellerShopId",
                principalTable: "SellerShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProduct_Users_SellerId",
                table: "BaseProduct",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_BaseProduct_BaseProductId",
                table: "Image",
                column: "BaseProductId",
                principalTable: "BaseProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_BaseProduct_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "BaseProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProduct_Color_ColorId",
                table: "BaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProduct_Image_MainImageId",
                table: "BaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProduct_SellerShop_SellerShopId",
                table: "BaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProduct_Users_SellerId",
                table: "BaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_BaseProduct_BaseProductId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_BaseProduct_ProductId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseProduct",
                table: "BaseProduct");

            migrationBuilder.RenameTable(
                name: "BaseProduct",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProduct_SellerShopId",
                table: "Products",
                newName: "IX_Products_SellerShopId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProduct_SellerId",
                table: "Products",
                newName: "IX_Products_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProduct_MainImageId",
                table: "Products",
                newName: "IX_Products_MainImageId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProduct_ColorId",
                table: "Products",
                newName: "IX_Products_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_BaseProductId",
                table: "Image",
                column: "BaseProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Color_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Image_MainImageId",
                table: "Products",
                column: "MainImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SellerShop_SellerShopId",
                table: "Products",
                column: "SellerShopId",
                principalTable: "SellerShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Products_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

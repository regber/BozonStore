using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class add_TPT : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompressorType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CoolingVolume",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DefrostingType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Depth",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Embedded",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EnergyConsumptionClass",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FreezerVolume",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FreezingPower",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalVolume",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "BaseProducts");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerShopId",
                table: "BaseProducts",
                newName: "IX_BaseProducts_SellerShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerId",
                table: "BaseProducts",
                newName: "IX_BaseProducts_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_MainImageId",
                table: "BaseProducts",
                newName: "IX_BaseProducts_MainImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseProducts",
                table: "BaseProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Embedded = table.Column<bool>(type: "bit", nullable: false),
                    EnergyConsumptionClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    TotalVolume = table.Column<int>(type: "int", nullable: false),
                    DefrostingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoolingVolume = table.Column<int>(type: "int", nullable: false),
                    FreezerVolume = table.Column<int>(type: "int", nullable: false),
                    FreezingPower = table.Column<int>(type: "int", nullable: false),
                    CompressorType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fridges_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_ColorId",
                table: "Fridges",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProducts_Image_MainImageId",
                table: "BaseProducts",
                column: "MainImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProducts_SellerShop_SellerShopId",
                table: "BaseProducts",
                column: "SellerShopId",
                principalTable: "SellerShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProducts_Users_SellerId",
                table: "BaseProducts",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_BaseProducts_BaseProductId",
                table: "Image",
                column: "BaseProductId",
                principalTable: "BaseProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_BaseProducts_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "BaseProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProducts_Image_MainImageId",
                table: "BaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProducts_SellerShop_SellerShopId",
                table: "BaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProducts_Users_SellerId",
                table: "BaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_BaseProducts_BaseProductId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_BaseProducts_ProductId",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseProducts",
                table: "BaseProducts");

            migrationBuilder.RenameTable(
                name: "BaseProducts",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProducts_SellerShopId",
                table: "Products",
                newName: "IX_Products_SellerShopId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProducts_SellerId",
                table: "Products",
                newName: "IX_Products_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProducts_MainImageId",
                table: "Products",
                newName: "IX_Products_MainImageId");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompressorType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoolingVolume",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefrostingType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Depth",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Embedded",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnergyConsumptionClass",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FreezerVolume",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FreezingPower",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalVolume",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

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

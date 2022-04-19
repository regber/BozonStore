using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class add_fridge_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImageData_MainImageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ImageData");

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

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alpha = table.Column<byte>(type: "tinyint", nullable: false),
                    Red = table.Column<byte>(type: "tinyint", nullable: false),
                    Green = table.Column<byte>(type: "tinyint", nullable: false),
                    Blue = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_BaseProductId",
                table: "Image",
                column: "BaseProductId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Color_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Image_MainImageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Image");

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

            migrationBuilder.CreateTable(
                name: "ImageData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseProductId = table.Column<int>(type: "int", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageData_Products_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_BaseProductId",
                table: "ImageData",
                column: "BaseProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImageData_MainImageId",
                table: "Products",
                column: "MainImageId",
                principalTable: "ImageData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

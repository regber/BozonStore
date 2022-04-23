﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasSeller_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasShops_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audios_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ProcessorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<float>(type: "real", nullable: false),
                    RAMVolume = table.Column<int>(type: "int", nullable: false),
                    RAMType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardDriveSize = table.Column<int>(type: "int", nullable: false),
                    VideoCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OSType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoCardType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        name: "FK_Fridges_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mixers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mixers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mixers_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Smartphones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Diagonal = table.Column<float>(type: "real", nullable: false),
                    BatteryVolume = table.Column<int>(type: "int", nullable: false),
                    BodyMaterialType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerticalResolution = table.Column<int>(type: "int", nullable: false),
                    HorizontalResolution = table.Column<int>(type: "int", nullable: false),
                    CoreCount = table.Column<int>(type: "int", nullable: false),
                    RAMVolume = table.Column<int>(type: "int", nullable: false),
                    EmbeddedMemoryVolume = table.Column<int>(type: "int", nullable: false),
                    MemoryCardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WirelessInterface = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smartphones_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Embedded = table.Column<bool>(type: "bit", nullable: false),
                    EnergyConsumptionClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    BurnersType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvenType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvenVolume = table.Column<int>(type: "int", nullable: false),
                    ControlType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stoves_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Televisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Diagonal = table.Column<int>(type: "int", nullable: false),
                    VerticalResolution = table.Column<int>(type: "int", nullable: false),
                    HorizontalResolution = table.Column<int>(type: "int", nullable: false),
                    FullHD = table.Column<bool>(type: "bit", nullable: false),
                    HD = table.Column<bool>(type: "bit", nullable: false),
                    SmartTV = table.Column<bool>(type: "bit", nullable: false),
                    LightingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WirelessInterface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    CountHDMI = table.Column<int>(type: "int", nullable: false),
                    BracingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatrixType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Televisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Televisions_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WashingMachines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Embedded = table.Column<bool>(type: "bit", nullable: false),
                    EnergyConsumptionClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false),
                    SpinSpeed = table.Column<int>(type: "int", nullable: false),
                    WashingClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HaveDrying = table.Column<bool>(type: "bit", nullable: false),
                    ControlType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectDrive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WashingMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WashingMachines_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MainImageId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AngleGrinders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    DiameterDisc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngleGrinders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AngleGrinders_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Punchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    HolderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeedCount = table.Column<int>(type: "int", nullable: false),
                    Turnovers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punchers_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Installation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CupCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinks_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WallPanels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallPanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WallPanels_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallpapers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WallpaperType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallpapers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallpapers_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MainImageId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    PurchasShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseProducts_PurchasShops_PurchasShopId",
                        column: x => x.PurchasShopId,
                        principalTable: "PurchasShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseProducts_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PurchasProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_PurchaseProducts_PurchasProductId",
                        column: x => x.PurchasProductId,
                        principalTable: "PurchaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    SellerShopId = table.Column<int>(type: "int", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PurchaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchasShops_SellerShopId",
                        column: x => x.SellerShopId,
                        principalTable: "PurchasShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audios_ColorId",
                table: "Audios",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ColorId",
                table: "Computers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_ColorId",
                table: "Fridges",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PurchasProductId",
                table: "Image",
                column: "PurchasProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Mixers_ColorId",
                table: "Mixers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MainImageId",
                table: "Products",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_MainImageId",
                table: "PurchaseProducts",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_PurchasShopId",
                table: "PurchaseProducts",
                column: "PurchasShopId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_SellerId",
                table: "PurchaseProducts",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BuyerId",
                table: "Purchases",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductId",
                table: "Purchases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SellerId",
                table: "Purchases",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SellerShopId",
                table: "Purchases",
                column: "SellerShopId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasShops_SellerId",
                table: "PurchasShops",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_SellerId",
                table: "Shops",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_ColorId",
                table: "Smartphones",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoves_ColorId",
                table: "Stoves",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Televisions_ColorId",
                table: "Televisions",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_WashingMachines_ColorId",
                table: "WashingMachines",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Products_Id",
                table: "Audios",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Products_Id",
                table: "Computers",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fridges_Products_Id",
                table: "Fridges",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mixers_Products_Id",
                table: "Mixers",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Smartphones_Products_Id",
                table: "Smartphones",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoves_Products_Id",
                table: "Stoves",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Televisions_Products_Id",
                table: "Televisions",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachines_Products_Id",
                table: "WashingMachines",
                column: "Id",
                principalTable: "Products",
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
                name: "FK_PurchaseProducts_Image_MainImageId",
                table: "PurchaseProducts",
                column: "MainImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_PurchaseProducts_PurchasProductId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "AngleGrinders");

            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Mixers");

            migrationBuilder.DropTable(
                name: "Punchers");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Sinks");

            migrationBuilder.DropTable(
                name: "Smartphones");

            migrationBuilder.DropTable(
                name: "Stoves");

            migrationBuilder.DropTable(
                name: "Televisions");

            migrationBuilder.DropTable(
                name: "WallPanels");

            migrationBuilder.DropTable(
                name: "Wallpapers");

            migrationBuilder.DropTable(
                name: "WashingMachines");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "PurchaseProducts");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "PurchasShops");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

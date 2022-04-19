using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class add_TPT_for_remains_Prod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_AngleGrinders_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Audios_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Computers_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Computers_Color_ColorId",
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
                        name: "FK_Mixers_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mixers_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
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
                        name: "FK_Punchers_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
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
                        name: "FK_Sinks_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
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
                    MemoryCardType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smartphones_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Stoves_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Televisions_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Televisions_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
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
                        name: "FK_WallPanels_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
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
                        name: "FK_Wallpapers_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
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
                        name: "FK_WashingMachines_BaseProducts_Id",
                        column: x => x.Id,
                        principalTable: "BaseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WashingMachines_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
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
                name: "IX_Mixers_ColorId",
                table: "Mixers",
                column: "ColorId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AngleGrinders");

            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Mixers");

            migrationBuilder.DropTable(
                name: "Punchers");

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
        }
    }
}

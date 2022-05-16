using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class deletedColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Color_ColorId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Fridges_Color_ColorId",
                table: "Fridges");

            migrationBuilder.DropForeignKey(
                name: "FK_Headphoness_Color_ColorId",
                table: "Headphoness");

            migrationBuilder.DropForeignKey(
                name: "FK_Mixers_Color_ColorId",
                table: "Mixers");

            migrationBuilder.DropForeignKey(
                name: "FK_Smartphones_Color_ColorId",
                table: "Smartphones");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakerss_Color_ColorId",
                table: "Speakerss");

            migrationBuilder.DropForeignKey(
                name: "FK_Stoves_Color_ColorId",
                table: "Stoves");

            migrationBuilder.DropForeignKey(
                name: "FK_Televisions_Color_ColorId",
                table: "Televisions");

            migrationBuilder.DropForeignKey(
                name: "FK_WashingMachines_Color_ColorId",
                table: "WashingMachines");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_WashingMachines_ColorId",
                table: "WashingMachines");

            migrationBuilder.DropIndex(
                name: "IX_Televisions_ColorId",
                table: "Televisions");

            migrationBuilder.DropIndex(
                name: "IX_Stoves_ColorId",
                table: "Stoves");

            migrationBuilder.DropIndex(
                name: "IX_Speakerss_ColorId",
                table: "Speakerss");

            migrationBuilder.DropIndex(
                name: "IX_Smartphones_ColorId",
                table: "Smartphones");

            migrationBuilder.DropIndex(
                name: "IX_Mixers_ColorId",
                table: "Mixers");

            migrationBuilder.DropIndex(
                name: "IX_Headphoness_ColorId",
                table: "Headphoness");

            migrationBuilder.DropIndex(
                name: "IX_Fridges_ColorId",
                table: "Fridges");

            migrationBuilder.DropIndex(
                name: "IX_Computers_ColorId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "WashingMachines");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Televisions");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Stoves");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Speakerss");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Mixers");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Headphoness");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Fridges");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Computers");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "WashingMachines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Televisions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Stoves",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Speakerss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Smartphones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Mixers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Headphoness",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Fridges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Computers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "WashingMachines");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Televisions");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Stoves");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Speakerss");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Smartphones");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Mixers");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Headphoness");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Fridges");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Computers");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "WashingMachines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Televisions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Stoves",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Speakerss",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Smartphones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Mixers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Headphoness",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Fridges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alpha = table.Column<byte>(type: "tinyint", nullable: false),
                    Blue = table.Column<byte>(type: "tinyint", nullable: false),
                    Green = table.Column<byte>(type: "tinyint", nullable: false),
                    Red = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WashingMachines_ColorId",
                table: "WashingMachines",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Televisions_ColorId",
                table: "Televisions",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoves_ColorId",
                table: "Stoves",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakerss_ColorId",
                table: "Speakerss",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_ColorId",
                table: "Smartphones",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mixers_ColorId",
                table: "Mixers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Headphoness_ColorId",
                table: "Headphoness",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_ColorId",
                table: "Fridges",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ColorId",
                table: "Computers",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Color_ColorId",
                table: "Computers",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fridges_Color_ColorId",
                table: "Fridges",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Headphoness_Color_ColorId",
                table: "Headphoness",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mixers_Color_ColorId",
                table: "Mixers",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Smartphones_Color_ColorId",
                table: "Smartphones",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Speakerss_Color_ColorId",
                table: "Speakerss",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoves_Color_ColorId",
                table: "Stoves",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Televisions_Color_ColorId",
                table: "Televisions",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachines_Color_ColorId",
                table: "WashingMachines",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

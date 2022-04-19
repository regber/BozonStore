using Microsoft.EntityFrameworkCore.Migrations;

namespace BozonStore.Migrations
{
    public partial class add_ChangeWirelessInterfacePropertyInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_WirelessInterface",
                table: "Smartphones",
                newName: "WirelessInterface");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WirelessInterface",
                table: "Smartphones",
                newName: "_WirelessInterface");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingSiteManagementWebApp.Data.Migrations
{
    public partial class ChangeColNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "No",
                schema: "Identity",
                table: "Residences",
                newName: "DoorNo");

            migrationBuilder.RenameColumn(
                name: "Floors",
                schema: "Identity",
                table: "Buildings",
                newName: "NumberOfFloors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoorNo",
                schema: "Identity",
                table: "Residences",
                newName: "No");

            migrationBuilder.RenameColumn(
                name: "NumberOfFloors",
                schema: "Identity",
                table: "Buildings",
                newName: "Floors");
        }
    }
}

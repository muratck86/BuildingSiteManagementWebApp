using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingSiteManagementWebApp.Data.Migrations
{
    public partial class Residence_Building_FK_restrictDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_Buildings_BuildingId",
                schema: "Identity",
                table: "Residences");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_Buildings_BuildingId",
                schema: "Identity",
                table: "Residences",
                column: "BuildingId",
                principalSchema: "Identity",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_Buildings_BuildingId",
                schema: "Identity",
                table: "Residences");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_Buildings_BuildingId",
                schema: "Identity",
                table: "Residences",
                column: "BuildingId",
                principalSchema: "Identity",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

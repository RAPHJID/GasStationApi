using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GasStationApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCylinderToInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CylinderId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CylinderId",
                table: "Inventory",
                column: "CylinderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Cylinders_CylinderId",
                table: "Inventory",
                column: "CylinderId",
                principalTable: "Cylinders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Cylinders_CylinderId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_CylinderId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CylinderId",
                table: "Inventory");
        }
    }
}

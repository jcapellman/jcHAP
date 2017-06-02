using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jcHAP.Library.Migrations
{
    public partial class SensorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensoeData_SensorNodes_SensorNodeID",
                table: "SensoeData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensoeData",
                table: "SensoeData");

            migrationBuilder.RenameTable(
                name: "SensoeData",
                newName: "SensorData");

            migrationBuilder.RenameIndex(
                name: "IX_SensoeData_SensorNodeID",
                table: "SensorData",
                newName: "IX_SensorData_SensorNodeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorData",
                table: "SensorData",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorData_SensorNodes_SensorNodeID",
                table: "SensorData",
                column: "SensorNodeID",
                principalTable: "SensorNodes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorData_SensorNodes_SensorNodeID",
                table: "SensorData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorData",
                table: "SensorData");

            migrationBuilder.RenameTable(
                name: "SensorData",
                newName: "SensoeData");

            migrationBuilder.RenameIndex(
                name: "IX_SensorData_SensorNodeID",
                table: "SensoeData",
                newName: "IX_SensoeData_SensorNodeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensoeData",
                table: "SensoeData",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SensoeData_SensorNodes_SensorNodeID",
                table: "SensoeData",
                column: "SensorNodeID",
                principalTable: "SensorNodes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jcHAP.Library.Migrations
{
    public partial class SensorNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "SensoeData");

            migrationBuilder.DropColumn(
                name: "SensorName",
                table: "SensoeData");

            migrationBuilder.AddColumn<int>(
                name: "SensorNodeID",
                table: "SensoeData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SensorNodes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    LastReportedData = table.Column<string>(nullable: true),
                    LastReportedDate = table.Column<DateTime>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorNodes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensoeData_SensorNodeID",
                table: "SensoeData",
                column: "SensorNodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SensoeData_SensorNodes_SensorNodeID",
                table: "SensoeData",
                column: "SensorNodeID",
                principalTable: "SensorNodes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensoeData_SensorNodes_SensorNodeID",
                table: "SensoeData");

            migrationBuilder.DropTable(
                name: "SensorNodes");

            migrationBuilder.DropIndex(
                name: "IX_SensoeData_SensorNodeID",
                table: "SensoeData");

            migrationBuilder.DropColumn(
                name: "SensorNodeID",
                table: "SensoeData");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SensoeData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SensorName",
                table: "SensoeData",
                nullable: true);
        }
    }
}

using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace jcHAP.Library.Migrations
{
    public partial class SensorNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_SensorData_SensorNodeID",
                table: "SensorData",
                column: "SensorNodeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
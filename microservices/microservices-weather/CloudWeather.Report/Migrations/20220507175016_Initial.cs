using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudWeather.Report.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weatherReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageHighC = table.Column<decimal>(type: "numeric", nullable: false),
                    AverageLowC = table.Column<decimal>(type: "numeric", nullable: false),
                    RainfallTotalCentimetres = table.Column<decimal>(type: "numeric", nullable: false),
                    SnowTotalCentimetres = table.Column<decimal>(type: "numeric", nullable: false),
                    PostCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weatherReport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weatherReport");
        }
    }
}

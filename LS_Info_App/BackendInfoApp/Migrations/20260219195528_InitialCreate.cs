using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendInfoApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    nId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sCity = table.Column<string>(type: "text", nullable: false),
                    sCountry = table.Column<string>(type: "text", nullable: false),
                    dTempC = table.Column<double>(type: "double precision", nullable: false),
                    sConditionText = table.Column<string>(type: "text", nullable: false),
                    dWindKph = table.Column<double>(type: "double precision", nullable: false),
                    sWindDir = table.Column<string>(type: "text", nullable: false),
                    dFeelsLikeC = table.Column<double>(type: "double precision", nullable: false),
                    oRecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.nId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}

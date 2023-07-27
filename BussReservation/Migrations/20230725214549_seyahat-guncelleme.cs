using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussReservation.Migrations
{
    /// <inheritdoc />
    public partial class seyahatguncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KalkisTarihi",
                table: "guzergahlars");

            migrationBuilder.AddColumn<int>(
                name: "SeyahatSuresi",
                table: "guzergahlars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeyahatSuresi",
                table: "guzergahlars");

            migrationBuilder.AddColumn<DateTime>(
                name: "KalkisTarihi",
                table: "guzergahlars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

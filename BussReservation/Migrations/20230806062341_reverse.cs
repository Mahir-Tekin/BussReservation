using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussReservation.Migrations
{
    /// <inheritdoc />
    public partial class reverse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guzergah",
                table: "Buses",
                newName: "GuzergahlarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuzergahlarId",
                table: "Buses",
                newName: "Guzergah");
        }
    }
}

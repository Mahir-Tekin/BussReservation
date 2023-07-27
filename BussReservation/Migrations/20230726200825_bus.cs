using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussReservation.Migrations
{
    /// <inheritdoc />
    public partial class bus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wifi",
                table: "Buses",
                newName: "FirmaLogo");

            migrationBuilder.RenameColumn(
                name: "Priz",
                table: "Buses",
                newName: "Firma");

            migrationBuilder.RenameColumn(
                name: "Guzergah",
                table: "Buses",
                newName: "GuzergahlarId");

            migrationBuilder.AlterColumn<string>(
                name: "varis",
                table: "guzergahlars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "kalkis",
                table: "guzergahlars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Koltuk",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuzergahlarId",
                table: "Buses",
                newName: "Guzergah");

            migrationBuilder.RenameColumn(
                name: "FirmaLogo",
                table: "Buses",
                newName: "Wifi");

            migrationBuilder.RenameColumn(
                name: "Firma",
                table: "Buses",
                newName: "Priz");

            migrationBuilder.AlterColumn<string>(
                name: "varis",
                table: "guzergahlars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "kalkis",
                table: "guzergahlars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "Koltuk",
                table: "Buses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

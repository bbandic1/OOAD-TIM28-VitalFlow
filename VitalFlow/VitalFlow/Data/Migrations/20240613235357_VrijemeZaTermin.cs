using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitalFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class VrijemeZaTermin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "datum",
                table: "Termin",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "vrijeme",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vrijeme",
                table: "Termin");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datum",
                table: "Termin",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}

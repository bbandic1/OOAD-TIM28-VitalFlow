using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitalFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrugaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kriticnaLinija",
                table: "Zaliha",
                newName: "kriticnaLiinija");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datum",
                table: "Termin",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kriticnaLiinija",
                table: "Zaliha",
                newName: "kriticnaLinija");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "datum",
                table: "Termin",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}

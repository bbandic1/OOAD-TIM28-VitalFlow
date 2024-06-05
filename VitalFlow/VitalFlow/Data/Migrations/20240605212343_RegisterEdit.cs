using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitalFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class RegisterEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Dodajte samo izmene koje se odnose na nova polja
            migrationBuilder.AddColumn<int>(
                name: "krvnaGrupa",
                table: "Korisnik",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Uklonite dodate kolone prilikom vraćanja migracije unazad
            migrationBuilder.DropColumn(
                name: "krvnaGrupa",
                table: "Korisnik");
        }
    }
}


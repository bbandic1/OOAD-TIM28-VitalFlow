using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalFlow.Data.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Proverite da li tabela već postoji
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Hub' and xtype='U')
                BEGIN
                    CREATE TABLE [Hub] (
                        [hubID] int NOT NULL IDENTITY,
                        [terminID] int NOT NULL,
                        [zahtjevID] int NOT NULL,
                        CONSTRAINT [PK_Hub] PRIMARY KEY ([hubID])
                    );
                END
            ");

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imeIPrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumRođenja = table.Column<DateOnly>(type: "date", nullable: false),
                    jmbg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    krvnaGrupa = table.Column<int>(type: "int", nullable: false),
                    brojOtkazivanja = table.Column<int>(type: "int", nullable: false),
                    zahtjevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    terminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateOnly>(type: "date", nullable: false),
                    sala = table.Column<int>(type: "int", nullable: false),
                    jmbg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kapacitet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.terminID);
                });

            migrationBuilder.CreateTable(
                name: "TerminHub",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jmbg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    terminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminHub", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    zahtjevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kolicina = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    krvnaGrupa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.zahtjevID);
                });

            migrationBuilder.CreateTable(
                name: "ZahtjevHub",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zahtjevID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevHub", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Zaliha",
                columns: table => new
                {
                    hubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    krvnaGrupa = table.Column<int>(type: "int", nullable: false),
                    kolicina = table.Column<int>(type: "int", nullable: false),
                    kriticnaLinija = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaliha", x => x.hubID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "TerminHub");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "ZahtjevHub");

            migrationBuilder.DropTable(
                name: "Zaliha");

            // Proverite postojanje pre brisanja tabele
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sysobjects WHERE name='Hub' and xtype='U')
                BEGIN
                    DROP TABLE [Hub];
                END
            ");
        }
    }
}

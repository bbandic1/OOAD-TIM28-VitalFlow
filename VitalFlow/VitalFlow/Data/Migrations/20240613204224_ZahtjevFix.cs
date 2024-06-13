using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitalFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class ZahtjevFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Zaliha",
                table: "Zaliha");

            migrationBuilder.AlterColumn<int>(
                name: "hubID",
                table: "Zaliha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "krvnaGrupa",
                table: "Zahtjev",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zaliha",
                table: "Zaliha",
                column: "krvnaGrupa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Zaliha",
                table: "Zaliha");

            migrationBuilder.AlterColumn<int>(
                name: "hubID",
                table: "Zaliha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "krvnaGrupa",
                table: "Zahtjev",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zaliha",
                table: "Zaliha",
                column: "hubID");
        }
    }
}

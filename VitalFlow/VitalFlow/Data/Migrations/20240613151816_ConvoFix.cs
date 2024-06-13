using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitalFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zaliha_Hub_hubID",
                table: "Zaliha");

            migrationBuilder.RenameColumn(
                name: "krvnaGrupaString",
                table: "Zaliha",
                newName: "krvnaGrupa");

            migrationBuilder.AlterColumn<int>(
                name: "hubID",
                table: "Zaliha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "krvnaGrupa",
                table: "Zaliha",
                newName: "krvnaGrupaString");

            migrationBuilder.AlterColumn<int>(
                name: "hubID",
                table: "Zaliha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Zaliha_Hub_hubID",
                table: "Zaliha",
                column: "hubID",
                principalTable: "Hub",
                principalColumn: "hubID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

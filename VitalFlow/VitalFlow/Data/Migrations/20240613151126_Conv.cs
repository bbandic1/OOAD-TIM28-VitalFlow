using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitalFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class Conv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "krvnaGrupa",
                table: "Zaliha");

            migrationBuilder.AlterColumn<int>(
                name: "hubID",
                table: "Zaliha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "krvnaGrupaString",
                table: "Zaliha",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Zaliha_Hub_hubID",
                table: "Zaliha",
                column: "hubID",
                principalTable: "Hub",
                principalColumn: "hubID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zaliha_Hub_hubID",
                table: "Zaliha");

            migrationBuilder.DropColumn(
                name: "krvnaGrupaString",
                table: "Zaliha");

            migrationBuilder.AlterColumn<int>(
                name: "hubID",
                table: "Zaliha",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "krvnaGrupa",
                table: "Zaliha",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CoordenadorRegional_CoordenadorRegionalId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "CoordenadorRegionalId",
                table: "Cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CoordenadorRegional_CoordenadorRegionalId",
                table: "Cliente",
                column: "CoordenadorRegionalId",
                principalTable: "CoordenadorRegional",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CoordenadorRegional_CoordenadorRegionalId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "CoordenadorRegionalId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CoordenadorRegional_CoordenadorRegionalId",
                table: "Cliente",
                column: "CoordenadorRegionalId",
                principalTable: "CoordenadorRegional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

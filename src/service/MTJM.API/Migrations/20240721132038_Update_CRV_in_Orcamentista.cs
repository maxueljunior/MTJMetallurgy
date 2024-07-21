using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_CRV_in_Orcamentista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentista_CoordenadorRegional_CoordenadorRegionalId",
                table: "Orcamentista");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentista_CoordenadorRegionalId",
                table: "Orcamentista");

            migrationBuilder.AlterColumn<int>(
                name: "CoordenadorRegionalId",
                table: "Orcamentista",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentista_CoordenadorRegionalId",
                table: "Orcamentista",
                column: "CoordenadorRegionalId",
                unique: true,
                filter: "[CoordenadorRegionalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentista_CoordenadorRegional_CoordenadorRegionalId",
                table: "Orcamentista",
                column: "CoordenadorRegionalId",
                principalTable: "CoordenadorRegional",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentista_CoordenadorRegional_CoordenadorRegionalId",
                table: "Orcamentista");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentista_CoordenadorRegionalId",
                table: "Orcamentista");

            migrationBuilder.AlterColumn<int>(
                name: "CoordenadorRegionalId",
                table: "Orcamentista",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentista_CoordenadorRegionalId",
                table: "Orcamentista",
                column: "CoordenadorRegionalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentista_CoordenadorRegional_CoordenadorRegionalId",
                table: "Orcamentista",
                column: "CoordenadorRegionalId",
                principalTable: "CoordenadorRegional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Column_Produto_Id_In_Propostas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposta_Produto_ProdutoId",
                table: "Proposta");

            migrationBuilder.DropIndex(
                name: "IX_Proposta_ProdutoId",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Proposta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Proposta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_ProdutoId",
                table: "Proposta",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposta_Produto_ProdutoId",
                table: "Proposta",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }
    }
}

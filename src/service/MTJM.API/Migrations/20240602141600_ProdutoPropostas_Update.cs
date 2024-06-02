using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoPropostas_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaProduto_Produto_ProdutoId",
                table: "PropostaProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_PropostaProduto_Proposta_PropostaId",
                table: "PropostaProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropostaProduto",
                table: "PropostaProduto");

            migrationBuilder.DropIndex(
                name: "IX_PropostaProduto_PropostaId",
                table: "PropostaProduto");

            migrationBuilder.RenameTable(
                name: "PropostaProduto",
                newName: "PropostaProdutos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Proposta",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropostaProdutos",
                table: "PropostaProdutos",
                columns: new[] { "PropostaId", "ProdutoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_ProdutoId",
                table: "Proposta",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PropostaProdutos_ProdutoId",
                table: "PropostaProdutos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposta_Produto_ProdutoId",
                table: "Proposta",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaProdutos_Produto_ProdutoId",
                table: "PropostaProdutos",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaProdutos_Proposta_PropostaId",
                table: "PropostaProdutos",
                column: "PropostaId",
                principalTable: "Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposta_Produto_ProdutoId",
                table: "Proposta");

            migrationBuilder.DropForeignKey(
                name: "FK_PropostaProdutos_Produto_ProdutoId",
                table: "PropostaProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PropostaProdutos_Proposta_PropostaId",
                table: "PropostaProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Proposta_ProdutoId",
                table: "Proposta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropostaProdutos",
                table: "PropostaProdutos");

            migrationBuilder.DropIndex(
                name: "IX_PropostaProdutos_ProdutoId",
                table: "PropostaProdutos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Proposta");

            migrationBuilder.RenameTable(
                name: "PropostaProdutos",
                newName: "PropostaProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropostaProduto",
                table: "PropostaProduto",
                columns: new[] { "ProdutoId", "PropostaId" });

            migrationBuilder.CreateIndex(
                name: "IX_PropostaProduto_PropostaId",
                table: "PropostaProduto",
                column: "PropostaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaProduto_Produto_ProdutoId",
                table: "PropostaProduto",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaProduto_Proposta_PropostaId",
                table: "PropostaProduto",
                column: "PropostaId",
                principalTable: "Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

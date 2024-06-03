using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_Proposta_Servico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaServico_Proposta_PropostasId",
                table: "PropostaServico");

            migrationBuilder.DropForeignKey(
                name: "FK_PropostaServico_Servico_ServicosId",
                table: "PropostaServico");

            migrationBuilder.RenameColumn(
                name: "ServicosId",
                table: "PropostaServico",
                newName: "ServicoId");

            migrationBuilder.RenameColumn(
                name: "PropostasId",
                table: "PropostaServico",
                newName: "PropostaId");

            migrationBuilder.RenameIndex(
                name: "IX_PropostaServico_ServicosId",
                table: "PropostaServico",
                newName: "IX_PropostaServico_ServicoId");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "PropostaServico",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Horas",
                table: "PropostaServico",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lucratividade",
                table: "PropostaServico",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoPorHora",
                table: "PropostaServico",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaServico_Proposta_PropostaId",
                table: "PropostaServico",
                column: "PropostaId",
                principalTable: "Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaServico_Servico_ServicoId",
                table: "PropostaServico",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaServico_Proposta_PropostaId",
                table: "PropostaServico");

            migrationBuilder.DropForeignKey(
                name: "FK_PropostaServico_Servico_ServicoId",
                table: "PropostaServico");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "PropostaServico");

            migrationBuilder.DropColumn(
                name: "Horas",
                table: "PropostaServico");

            migrationBuilder.DropColumn(
                name: "Lucratividade",
                table: "PropostaServico");

            migrationBuilder.DropColumn(
                name: "PrecoPorHora",
                table: "PropostaServico");

            migrationBuilder.RenameColumn(
                name: "ServicoId",
                table: "PropostaServico",
                newName: "ServicosId");

            migrationBuilder.RenameColumn(
                name: "PropostaId",
                table: "PropostaServico",
                newName: "PropostasId");

            migrationBuilder.RenameIndex(
                name: "IX_PropostaServico_ServicoId",
                table: "PropostaServico",
                newName: "IX_PropostaServico_ServicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaServico_Proposta_PropostasId",
                table: "PropostaServico",
                column: "PropostasId",
                principalTable: "Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaServico_Servico_ServicosId",
                table: "PropostaServico",
                column: "ServicosId",
                principalTable: "Servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

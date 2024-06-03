﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_PrecoPorHora_PropostaServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Horas",
                table: "PropostaServico",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Horas",
                table: "PropostaServico",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}

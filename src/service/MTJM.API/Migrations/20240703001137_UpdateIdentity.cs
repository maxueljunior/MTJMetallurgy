using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "Cliente",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UserAccountId",
                table: "Cliente",
                column: "UserAccountId",
                unique: true,
                filter: "[UserAccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_AspNetUsers_UserAccountId",
                table: "Cliente",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_AspNetUsers_UserAccountId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UserAccountId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Cliente");
        }
    }
}

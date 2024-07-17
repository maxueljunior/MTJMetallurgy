using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentityWithCRV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "CoordenadorRegional",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoordenadorRegional_UserAccountId",
                table: "CoordenadorRegional",
                column: "UserAccountId",
                unique: true,
                filter: "[UserAccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CoordenadorRegional_AspNetUsers_UserAccountId",
                table: "CoordenadorRegional",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoordenadorRegional_AspNetUsers_UserAccountId",
                table: "CoordenadorRegional");

            migrationBuilder.DropIndex(
                name: "IX_CoordenadorRegional_UserAccountId",
                table: "CoordenadorRegional");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "CoordenadorRegional");
        }
    }
}

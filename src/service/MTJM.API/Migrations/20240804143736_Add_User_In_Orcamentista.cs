using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTJM.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_In_Orcamentista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "Orcamentista",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentista_UserAccountId",
                table: "Orcamentista",
                column: "UserAccountId",
                unique: true,
                filter: "[UserAccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentista_AspNetUsers_UserAccountId",
                table: "Orcamentista",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentista_AspNetUsers_UserAccountId",
                table: "Orcamentista");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentista_UserAccountId",
                table: "Orcamentista");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Orcamentista");
        }
    }
}

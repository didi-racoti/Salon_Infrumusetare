using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Infrumusetare.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Serviciu_ServiciuID",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "ServiciuID",
                table: "Client",
                newName: "ServiciuSelectatID");

            migrationBuilder.RenameIndex(
                name: "IX_Client_ServiciuID",
                table: "Client",
                newName: "IX_Client_ServiciuSelectatID");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_ClientID",
                table: "Serviciu",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Serviciu_ServiciuSelectatID",
                table: "Client",
                column: "ServiciuSelectatID",
                principalTable: "Serviciu",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Client_ClientID",
                table: "Serviciu",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Serviciu_ServiciuSelectatID",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Client_ClientID",
                table: "Serviciu");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_ClientID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Serviciu");

            migrationBuilder.RenameColumn(
                name: "ServiciuSelectatID",
                table: "Client",
                newName: "ServiciuID");

            migrationBuilder.RenameIndex(
                name: "IX_Client_ServiciuSelectatID",
                table: "Client",
                newName: "IX_Client_ServiciuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Serviciu_ServiciuID",
                table: "Client",
                column: "ServiciuID",
                principalTable: "Serviciu",
                principalColumn: "ID");
        }
    }
}

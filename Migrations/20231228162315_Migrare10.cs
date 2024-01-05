using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Infrumusetare.Migrations
{
    public partial class Migrare10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    ServiciuID = table.Column<int>(type: "int", nullable: true),
                    SpecialistID = table.Column<int>(type: "int", nullable: true),
                    Ora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programare_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Specialist_SpecialistID",
                        column: x => x.SpecialistID,
                        principalTable: "Specialist",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ClientID",
                table: "Programare",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ServiciuID",
                table: "Programare",
                column: "ServiciuID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_SpecialistID",
                table: "Programare",
                column: "SpecialistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");
        }
    }
}

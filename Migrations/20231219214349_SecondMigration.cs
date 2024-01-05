using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Infrumusetare.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialistID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specialist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialitate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnVechime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_SpecialistID",
                table: "Serviciu",
                column: "SpecialistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Specialist_SpecialistID",
                table: "Serviciu",
                column: "SpecialistID",
                principalTable: "Specialist",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Specialist_SpecialistID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Specialist");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_SpecialistID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "SpecialistID",
                table: "Serviciu");
        }
    }
}

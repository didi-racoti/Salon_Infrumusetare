using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Infrumusetare.Migrations
{
    public partial class migrare11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Serviciu_ServiciuID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Specialist_SpecialistID",
                table: "Programare");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialistID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiciuID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Serviciu_ServiciuID",
                table: "Programare",
                column: "ServiciuID",
                principalTable: "Serviciu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Specialist_SpecialistID",
                table: "Programare",
                column: "SpecialistID",
                principalTable: "Specialist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Serviciu_ServiciuID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Specialist_SpecialistID",
                table: "Programare");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialistID",
                table: "Programare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiciuID",
                table: "Programare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Programare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Serviciu_ServiciuID",
                table: "Programare",
                column: "ServiciuID",
                principalTable: "Serviciu",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Specialist_SpecialistID",
                table: "Programare",
                column: "SpecialistID",
                principalTable: "Specialist",
                principalColumn: "ID");
        }
    }
}

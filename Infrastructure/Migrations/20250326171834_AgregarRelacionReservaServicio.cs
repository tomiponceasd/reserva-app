using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionReservaServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Servicio",
                table: "Reservas");

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Manicura" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ServicioId",
                table: "Reservas",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Servicios_ServicioId",
                table: "Reservas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Servicios_ServicioId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ServicioId",
                table: "Reservas");

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Reservas");

            migrationBuilder.AddColumn<string>(
                name: "Servicio",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
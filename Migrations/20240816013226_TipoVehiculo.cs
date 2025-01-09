using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class TipoVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoVehiculoId",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TipoVehiculoId",
                table: "Vehiculos",
                column: "TipoVehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_TipoVehiculos_TipoVehiculoId",
                table: "Vehiculos",
                column: "TipoVehiculoId",
                principalTable: "TipoVehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_TipoVehiculos_TipoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropTable(
                name: "TipoVehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_TipoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "TipoVehiculoId",
                table: "Vehiculos");
        }
    }
}

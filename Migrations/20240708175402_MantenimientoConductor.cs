using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class MantenimientoConductor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConductorId",
                table: "Mantenimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_ConductorId",
                table: "Mantenimientos",
                column: "ConductorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Conductores_ConductorId",
                table: "Mantenimientos",
                column: "ConductorId",
                principalTable: "Conductores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Conductores_ConductorId",
                table: "Mantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_Mantenimientos_ConductorId",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "Mantenimientos");
        }
    }
}

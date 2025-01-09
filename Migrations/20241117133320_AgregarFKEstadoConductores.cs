using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFKEstadoConductores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Agregar la clave foránea a EstadoConductoresId
            migrationBuilder.AddForeignKey(
                name: "FK_Conductores_EstadoConductores_EstadoConductoresId",
                table: "Conductores",
                column: "EstadoConductoresId",
                principalTable: "EstadoConductores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
           name: "FK_Conductores_EstadoConductores_EstadoConductoresId",
           table: "Conductores");

        }
    }
}

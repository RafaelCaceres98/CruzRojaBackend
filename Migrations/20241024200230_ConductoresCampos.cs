using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class ConductoresCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Conductores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoLicencia",
                table: "Conductores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Conductores");

            migrationBuilder.DropColumn(
                name: "TipoLicencia",
                table: "Conductores");
        }
    }
}

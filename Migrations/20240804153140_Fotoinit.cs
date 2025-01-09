using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class Fotoinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "RegKilometrajes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "RegKilometrajes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class FechasKilometrajes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaKilometraje",
                table: "RegKilometrajes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaKilometrajeLlegada",
                table: "RegKilometrajes",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaKilometraje",
                table: "RegKilometrajes");

            migrationBuilder.DropColumn(
                name: "FechaKilometrajeLlegada",
                table: "RegKilometrajes");
        }
    }
}

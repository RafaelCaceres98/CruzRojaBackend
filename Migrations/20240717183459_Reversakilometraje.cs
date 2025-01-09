using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class Reversakilometraje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegKilometrajes_TipoRecorridos_TipoRecorridoId",
                table: "RegKilometrajes");

            migrationBuilder.DropIndex(
                name: "IX_RegKilometrajes_TipoRecorridoId",
                table: "RegKilometrajes");

            migrationBuilder.DropColumn(
                name: "TipoRecorridoId",
                table: "RegKilometrajes");

            migrationBuilder.AlterColumn<string>(
                name: "Kilometraje",
                table: "RegKilometrajes",
                type: "nvarchar(max)",
                precision: 18,
                scale: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "RegKilometrajes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Kilometrajellegada",
                table: "RegKilometrajes",
                type: "nvarchar(max)",
                precision: 18,
                scale: 1,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "RegKilometrajes");

            migrationBuilder.DropColumn(
                name: "Kilometrajellegada",
                table: "RegKilometrajes");

            migrationBuilder.AlterColumn<string>(
                name: "Kilometraje",
                table: "RegKilometrajes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldPrecision: 18,
                oldScale: 1);

            migrationBuilder.AddColumn<int>(
                name: "TipoRecorridoId",
                table: "RegKilometrajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegKilometrajes_TipoRecorridoId",
                table: "RegKilometrajes",
                column: "TipoRecorridoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegKilometrajes_TipoRecorridos_TipoRecorridoId",
                table: "RegKilometrajes",
                column: "TipoRecorridoId",
                principalTable: "TipoRecorridos",
                principalColumn: "Id");
        }
    }
}

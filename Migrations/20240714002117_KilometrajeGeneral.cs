using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class KilometrajeGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRecorridos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRecorridos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegKilometrajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    ConductorId = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Kilometraje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    TipoRecorridoId = table.Column<int>(type: "int", nullable: false),
                    Novedades = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegKilometrajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegKilometrajes_Conductores_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegKilometrajes_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegKilometrajes_TipoRecorridos_TipoRecorridoId",
                        column: x => x.TipoRecorridoId,
                        principalTable: "TipoRecorridos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegKilometrajes_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegKilometrajes_ConductorId",
                table: "RegKilometrajes",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegKilometrajes_ProyectoId",
                table: "RegKilometrajes",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegKilometrajes_TipoRecorridoId",
                table: "RegKilometrajes",
                column: "TipoRecorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegKilometrajes_VehiculoId",
                table: "RegKilometrajes",
                column: "VehiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegKilometrajes");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "TipoRecorridos");
        }
    }
}

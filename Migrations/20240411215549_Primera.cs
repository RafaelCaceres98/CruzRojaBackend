using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class Primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaComprasYServicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaComprasYServicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetallePeriodicidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePeriodicidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Latonerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Latonerias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcaVehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaVehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mecanicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMantenimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloVehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MarcaVehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloVehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloVehiculos_MarcaVehiculos_MarcaVehiculoId",
                        column: x => x.MarcaVehiculoId,
                        principalTable: "MarcaVehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    clave = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_EstadoUsuarios_EstadoUsuarioId",
                        column: x => x.EstadoUsuarioId,
                        principalTable: "EstadoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_RolUsuarios_RolUsuarioId",
                        column: x => x.RolUsuarioId,
                        principalTable: "RolUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    anio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Chasis = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Motor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NumMovil = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Propiedad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    anioRecibidoVehiculo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Esactivo = table.Column<bool>(type: "BIT", nullable: false),
                    MarcaVehiculoId = table.Column<int>(type: "int", nullable: false),
                    ModeloVehiculoId = table.Column<int>(type: "int", nullable: false),
                    LatoneriaId = table.Column<int>(type: "int", nullable: false),
                    MecanicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Latonerias_LatoneriaId",
                        column: x => x.LatoneriaId,
                        principalTable: "Latonerias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculos_MarcaVehiculos_MarcaVehiculoId",
                        column: x => x.MarcaVehiculoId,
                        principalTable: "MarcaVehiculos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculos_Mecanicas_MecanicaId",
                        column: x => x.MecanicaId,
                        principalTable: "Mecanicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculos_ModeloVehiculos_ModeloVehiculoId",
                        column: x => x.ModeloVehiculoId,
                        principalTable: "ModeloVehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HojadeVidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaComprasYServiciosId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    TipoMantenimientoId = table.Column<int>(type: "int", nullable: false),
                    KilometrajeActual = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    KIlometrajeDeCierre = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProveedorDeServicio = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    NumFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorPagado = table.Column<double>(type: "float", nullable: false),
                    ConductorId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojadeVidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HojadeVidas_CategoriaComprasYServicios_CategoriaComprasYServiciosId",
                        column: x => x.CategoriaComprasYServiciosId,
                        principalTable: "CategoriaComprasYServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HojadeVidas_Conductores_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HojadeVidas_TipoMantenimientos_TipoMantenimientoId",
                        column: x => x.TipoMantenimientoId,
                        principalTable: "TipoMantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HojadeVidas_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    DetallePeriodicidadId = table.Column<int>(type: "int", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    TiempoDias = table.Column<int>(type: "int", precision: 18, scale: 1, nullable: false),
                    KilometrajeActual = table.Column<int>(type: "int", precision: 18, scale: 1, nullable: false),
                    KilometrajeParaMantenimiento = table.Column<int>(type: "int", precision: 18, scale: 1, nullable: false),
                    PeriodicidadKilometraje = table.Column<int>(type: "int", precision: 18, scale: 1, nullable: false),
                    PeriodicidadXTiempo = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_DetallePeriodicidades_DetallePeriodicidadId",
                        column: x => x.DetallePeriodicidadId,
                        principalTable: "DetallePeriodicidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOAT_TECNOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOAT_TECNOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOAT_TECNOs_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOATs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Periodicidad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SOAT_TECNOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOATs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOATs_SOAT_TECNOs_SOAT_TECNOId",
                        column: x => x.SOAT_TECNOId,
                        principalTable: "SOAT_TECNOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TECNOMECANICAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Periodicidad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SOAT_TECNOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TECNOMECANICAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TECNOMECANICAs_SOAT_TECNOs_SOAT_TECNOId",
                        column: x => x.SOAT_TECNOId,
                        principalTable: "SOAT_TECNOs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HojadeVidas_CategoriaComprasYServiciosId",
                table: "HojadeVidas",
                column: "CategoriaComprasYServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_HojadeVidas_ConductorId",
                table: "HojadeVidas",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_HojadeVidas_TipoMantenimientoId",
                table: "HojadeVidas",
                column: "TipoMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_HojadeVidas_VehiculoId",
                table: "HojadeVidas",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_DetallePeriodicidadId",
                table: "Mantenimientos",
                column: "DetallePeriodicidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_VehiculoId",
                table: "Mantenimientos",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloVehiculos_MarcaVehiculoId",
                table: "ModeloVehiculos",
                column: "MarcaVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_SOAT_TECNOs_VehiculoId",
                table: "SOAT_TECNOs",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_SOATs_SOAT_TECNOId",
                table: "SOATs",
                column: "SOAT_TECNOId");

            migrationBuilder.CreateIndex(
                name: "IX_TECNOMECANICAs_SOAT_TECNOId",
                table: "TECNOMECANICAs",
                column: "SOAT_TECNOId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoUsuarioId",
                table: "Usuarios",
                column: "EstadoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolUsuarioId",
                table: "Usuarios",
                column: "RolUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_LatoneriaId",
                table: "Vehiculos",
                column: "LatoneriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_MarcaVehiculoId",
                table: "Vehiculos",
                column: "MarcaVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_MecanicaId",
                table: "Vehiculos",
                column: "MecanicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ModeloVehiculoId",
                table: "Vehiculos",
                column: "ModeloVehiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojadeVidas");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "SOATs");

            migrationBuilder.DropTable(
                name: "TECNOMECANICAs");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CategoriaComprasYServicios");

            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropTable(
                name: "TipoMantenimientos");

            migrationBuilder.DropTable(
                name: "DetallePeriodicidades");

            migrationBuilder.DropTable(
                name: "SOAT_TECNOs");

            migrationBuilder.DropTable(
                name: "EstadoUsuarios");

            migrationBuilder.DropTable(
                name: "RolUsuarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Latonerias");

            migrationBuilder.DropTable(
                name: "Mecanicas");

            migrationBuilder.DropTable(
                name: "ModeloVehiculos");

            migrationBuilder.DropTable(
                name: "MarcaVehiculos");
        }
    }
}

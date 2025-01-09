﻿// <auto-generated />
using System;
using Backend_CruzRoja;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241117131717_ConductorEstado")]
    partial class ConductorEstado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend_CruzRoja.Entidades.CategoriaComprasYServicios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(110)
                        .HasColumnType("nvarchar(110)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaComprasYServicios");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Conductor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EstadoConductoresId")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TipoLicencia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoConductoresId");

                    b.ToTable("Conductores");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.DetallePeriodicidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("DetallePeriodicidades");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.EmailSettings", b =>
                {
                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SmtpPort")
                        .HasColumnType("int");

                    b.Property<string>("SmtpServer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("EmailSettings", (string)null);
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.EstadoConductor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("EstadoConductores");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.EstadoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("EstadoUsuarios");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.HojadeVida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaComprasYServiciosId")
                        .HasColumnType("int");

                    b.Property<int>("ConductorId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("KIlometrajeDeCierre")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("KilometrajeActual")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("NumFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("ProveedorDeServicio")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("TipoMantenimientoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorPagado")
                        .HasColumnType("float");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaComprasYServiciosId");

                    b.HasIndex("ConductorId");

                    b.HasIndex("TipoMantenimientoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("HojadeVidas");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Latoneria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Latonerias");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConductorId")
                        .HasColumnType("int");

                    b.Property<int>("DetallePeriodicidadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime");

                    b.Property<int>("KilometrajeActual")
                        .HasPrecision(18, 1)
                        .HasColumnType("int");

                    b.Property<int>("KilometrajeParaMantenimiento")
                        .HasPrecision(18, 1)
                        .HasColumnType("int");

                    b.Property<int>("PeriodicidadKilometraje")
                        .HasPrecision(18, 1)
                        .HasColumnType("int");

                    b.Property<string>("PeriodicidadXTiempo")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("TiempoDias")
                        .HasPrecision(18, 1)
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConductorId");

                    b.HasIndex("DetallePeriodicidadId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.MarcaVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("MarcaVehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Mecanica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Mecanicas");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.ModeloVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("MarcaVehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarcaVehiculoId");

                    b.ToTable("ModeloVehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.RegKilometraje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConductorId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaKilometraje")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaKilometrajeLlegada")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Kilometraje")
                        .IsRequired()
                        .HasPrecision(18, 1)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kilometrajellegada")
                        .IsRequired()
                        .HasPrecision(18, 1)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Novedades")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConductorId");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("RegKilometrajes");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.RolUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("RolUsuarios");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.SOAT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime");

                    b.Property<string>("Periodicidad")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("SOAT_TECNOId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SOAT_TECNOId");

                    b.ToTable("SOATs");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.SOAT_TECNO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehiculoId");

                    b.ToTable("SOAT_TECNOs");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.TECNOMECANICA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime");

                    b.Property<string>("Periodicidad")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("SOAT_TECNOId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SOAT_TECNOId");

                    b.ToTable("TECNOMECANICAs");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.TipoMantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("TipoMantenimientos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.TipoRecorrido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("TipoRecorridos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.TipoVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("TipoVehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.TokenRecuperacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TokensRecuperacion");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("RolUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoUsuarioId");

                    b.HasIndex("RolUsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Chasis")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("Esactivo")
                        .HasColumnType("BIT");

                    b.Property<int>("LatoneriaId")
                        .HasColumnType("int");

                    b.Property<int>("MarcaVehiculoId")
                        .HasColumnType("int");

                    b.Property<int>("MecanicaId")
                        .HasColumnType("int");

                    b.Property<int>("ModeloVehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NumMovil")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Propiedad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("anio")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("anioRecibidoVehiculo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("LatoneriaId");

                    b.HasIndex("MarcaVehiculoId");

                    b.HasIndex("MecanicaId");

                    b.HasIndex("ModeloVehiculoId");

                    b.HasIndex("TipoVehiculoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Conductor", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.EstadoConductor", "EstadoConductores")
                        .WithMany()
                        .HasForeignKey("EstadoConductoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoConductores");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.HojadeVida", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.CategoriaComprasYServicios", "CategoriaComprasYServicios")
                        .WithMany()
                        .HasForeignKey("CategoriaComprasYServiciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.Conductor", "Conductor")
                        .WithMany("HojadeVidas")
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.TipoMantenimiento", "TipoMantenimiento")
                        .WithMany()
                        .HasForeignKey("TipoMantenimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaComprasYServicios");

                    b.Navigation("Conductor");

                    b.Navigation("TipoMantenimiento");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Mantenimiento", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.Conductor", "Conductor")
                        .WithMany("Mantenimientoss")
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.DetallePeriodicidad", "DetallePeriodicidad")
                        .WithMany()
                        .HasForeignKey("DetallePeriodicidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conductor");

                    b.Navigation("DetallePeriodicidad");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.ModeloVehiculo", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.MarcaVehiculo", "MarcaVehiculo")
                        .WithMany()
                        .HasForeignKey("MarcaVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaVehiculo");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.RegKilometraje", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.Conductor", "Conductor")
                        .WithMany("RegKilometrajes")
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.Proyecto", "Proyecto")
                        .WithMany("RegKilometrajes")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.Vehiculo", "Vehiculo")
                        .WithMany("RegKilometrajes")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Conductor");

                    b.Navigation("Proyecto");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.SOAT", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.SOAT_TECNO", null)
                        .WithMany("SOATs")
                        .HasForeignKey("SOAT_TECNOId");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.SOAT_TECNO", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.TECNOMECANICA", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.SOAT_TECNO", null)
                        .WithMany("TECNOMECANICAs")
                        .HasForeignKey("SOAT_TECNOId");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Usuario", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.EstadoUsuario", "EstadoUsuario")
                        .WithMany()
                        .HasForeignKey("EstadoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.RolUsuario", "RolUsuario")
                        .WithMany()
                        .HasForeignKey("RolUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoUsuario");

                    b.Navigation("RolUsuario");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Vehiculo", b =>
                {
                    b.HasOne("Backend_CruzRoja.Entidades.Latoneria", "Latoneria")
                        .WithMany("Vehiculos")
                        .HasForeignKey("LatoneriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.MarcaVehiculo", "MarcaVehiculo")
                        .WithMany("Vehiculos")
                        .HasForeignKey("MarcaVehiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.Mecanica", "Mecanica")
                        .WithMany("Vehiculos")
                        .HasForeignKey("MecanicaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.ModeloVehiculo", "ModeloVehiculo")
                        .WithMany("Vehiculos")
                        .HasForeignKey("ModeloVehiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend_CruzRoja.Entidades.TipoVehiculo", "TipoVehiculo")
                        .WithMany()
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Latoneria");

                    b.Navigation("MarcaVehiculo");

                    b.Navigation("Mecanica");

                    b.Navigation("ModeloVehiculo");

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Conductor", b =>
                {
                    b.Navigation("HojadeVidas");

                    b.Navigation("Mantenimientoss");

                    b.Navigation("RegKilometrajes");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Latoneria", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.MarcaVehiculo", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Mecanica", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.ModeloVehiculo", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Proyecto", b =>
                {
                    b.Navigation("RegKilometrajes");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.SOAT_TECNO", b =>
                {
                    b.Navigation("SOATs");

                    b.Navigation("TECNOMECANICAs");
                });

            modelBuilder.Entity("Backend_CruzRoja.Entidades.Vehiculo", b =>
                {
                    b.Navigation("RegKilometrajes");
                });
#pragma warning restore 612, 618
        }
    }
}

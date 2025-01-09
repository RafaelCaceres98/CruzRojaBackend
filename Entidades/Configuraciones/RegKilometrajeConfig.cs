using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class RegKilometrajeConfig : IEntityTypeConfiguration<RegKilometraje>
    {
        public void Configure(EntityTypeBuilder<RegKilometraje> builder)
        {
            builder.Property(x => x.Kilometraje).HasPrecision(18, 1);
            builder.Property(x => x.Kilometrajellegada).HasPrecision(18, 1);
            builder.Property(x => x.Novedades).HasMaxLength(500);
            builder.Property(x => x.Descripcion).HasMaxLength(500);
            builder.Property(x => x.NumeroDocumento).HasMaxLength(500);
            builder.Property(x => x.Fecha).HasColumnType("datetime2");

            // Configuración de relaciones con DeleteBehavior.Restrict para evitar eliminaciones en cascada
            builder.HasOne(x => x.Vehiculo)
                .WithMany(v => v.RegKilometrajes)
                .HasForeignKey(x => x.VehiculoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Conductor)
                .WithMany(c => c.RegKilometrajes)
                .HasForeignKey(x => x.ConductorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Proyecto)
                .WithMany(p => p.RegKilometrajes)
                .HasForeignKey(x => x.ProyectoId)
                .OnDelete(DeleteBehavior.NoAction);


            // Configuración para la propiedad Foto
            builder.Property(e => e.Foto)
                   .HasColumnType("varbinary(max)"); // Para almacenar datos binarios

            builder.Property(x => x.FechaKilometraje)
              .HasColumnType("datetime2");

            builder.Property(x => x.FechaKilometrajeLlegada)
                .HasColumnType("datetime2");





        }
    }
}

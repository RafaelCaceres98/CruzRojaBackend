using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class MantenimientoConfig : IEntityTypeConfiguration<Mantenimiento>
    {
        void IEntityTypeConfiguration<Mantenimiento>.Configure(EntityTypeBuilder<Mantenimiento> builder)
        {
            builder.Property(x => x.FechaSolicitud).HasColumnType("datetime");
            builder.Property(x => x.FechaVencimiento).HasColumnType("datetime");
            builder.Property(x => x.TiempoDias).HasPrecision(18, 1);
            builder.Property(x => x.KilometrajeActual).HasPrecision(18, 1);
            builder.Property(x => x.KilometrajeParaMantenimiento).HasPrecision(18, 1);
            builder.Property(x => x.PeriodicidadKilometraje).HasPrecision(18, 1);
            builder.Property(x => x.PeriodicidadXTiempo).HasMaxLength(70);

            builder.HasOne(x => x.Conductor)
       .WithMany(m => m.Mantenimientoss)
        .HasForeignKey(x => x.ConductorId)
        .OnDelete(DeleteBehavior.NoAction); // Evita eliminaciones en cascada
        }
    }
}

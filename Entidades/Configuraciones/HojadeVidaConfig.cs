using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class HojadeVidaConfig : IEntityTypeConfiguration<HojadeVida>
    {
        public void Configure(EntityTypeBuilder<HojadeVida> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(90);
            builder.Property(x => x.KilometrajeActual).HasMaxLength(90);
            builder.Property(x => x.KIlometrajeDeCierre).HasMaxLength(90);
            builder.Property(x => x.Fecha).HasColumnType("datetime");
            builder.Property(x => x.ProveedorDeServicio).HasMaxLength(90);
            builder.Property(x => x.Observaciones).HasMaxLength(90);

            builder.HasOne(x => x.Conductor)
          .WithMany(m => m.HojadeVidas)
           .HasForeignKey(x => x.ConductorId)
           .OnDelete(DeleteBehavior.NoAction); // Evita eliminaciones en cascada

        }
    }
}

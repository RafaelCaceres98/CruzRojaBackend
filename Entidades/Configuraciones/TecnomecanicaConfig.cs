using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class TecnomecanicaConfig : IEntityTypeConfiguration<TECNOMECANICA>
    {
        public void Configure(EntityTypeBuilder<TECNOMECANICA> builder)
        {
            builder.Property(x => x.FechaSolicitud).HasColumnType("datetime");
            builder.Property(x => x.FechaVencimiento).HasColumnType("datetime");
            builder.Property(x => x.Periodicidad).HasMaxLength(60);
        }
    }
}

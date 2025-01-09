using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class DetallePeriodicidadConfig : IEntityTypeConfiguration<DetallePeriodicidad>
    {
        public void Configure(EntityTypeBuilder<DetallePeriodicidad> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(70);
        }
    }
}

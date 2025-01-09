using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class TipoMantenimientoConfig : IEntityTypeConfiguration<TipoMantenimiento>
    {
        public void Configure(EntityTypeBuilder<TipoMantenimiento> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(60);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class TipoRecorridoConfig : IEntityTypeConfiguration<TipoRecorrido>
    {
        public void Configure(EntityTypeBuilder<TipoRecorrido> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(70);
        }
    }
}

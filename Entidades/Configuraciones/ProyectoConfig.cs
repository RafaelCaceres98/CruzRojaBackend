using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class ProyectoConfig : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(70);
        }
    }
}

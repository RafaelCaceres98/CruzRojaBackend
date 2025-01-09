using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class CategoriaComprasYServiciosConfig : IEntityTypeConfiguration<CategoriaComprasYServicios>
    {
        public void Configure(EntityTypeBuilder<CategoriaComprasYServicios> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(110);
        }
    }
}

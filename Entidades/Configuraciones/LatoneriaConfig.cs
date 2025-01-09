using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class LatoneriaConfig : IEntityTypeConfiguration<Latoneria>
    {
        public void Configure(EntityTypeBuilder<Latoneria> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(30);
        }
    }
}

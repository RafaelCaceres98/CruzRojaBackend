using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class EstadoConductorConfig : IEntityTypeConfiguration<EstadoConductor>
    {
        public void Configure(EntityTypeBuilder<EstadoConductor> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(30);
        }
    
}
}

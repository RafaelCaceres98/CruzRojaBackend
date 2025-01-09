using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class EstadoUsuarioConfig : IEntityTypeConfiguration<EstadoUsuario>
    {
        public void Configure(EntityTypeBuilder<EstadoUsuario> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(30);
        }
    }
}

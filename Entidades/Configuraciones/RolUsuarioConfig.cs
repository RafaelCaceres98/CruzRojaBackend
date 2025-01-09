using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class RolUsuarioConfig : IEntityTypeConfiguration<RolUsuario>
    {
        public void Configure(EntityTypeBuilder<RolUsuario> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(60);
        }
    }
}

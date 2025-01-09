using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class MecanicaConfig : IEntityTypeConfiguration<Mecanica>
    {
        public void Configure(EntityTypeBuilder<Mecanica> builder)
        {

            builder.Property(x => x.Descripcion).HasMaxLength(30);
        }
    }
}

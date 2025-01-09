using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class ConductorConfig : IEntityTypeConfiguration<Conductor>
    {
        public void Configure(EntityTypeBuilder<Conductor> builder)
        {
            builder.Property(x => x.Nombres).HasMaxLength(100);
            builder.Property(x => x.Apellidos).HasMaxLength(100);
            builder.Property(x => x.NumeroIdentificacion).HasMaxLength(10);
            builder.Property(x => x.TipoLicencia).HasMaxLength(100);
            builder.Property(x => x.Categoria).HasMaxLength(100);


        }
    }
}

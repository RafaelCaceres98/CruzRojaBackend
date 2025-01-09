using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class SOAT_TECNOConfig : IEntityTypeConfiguration<SOAT_TECNO>
    {
        public void Configure(EntityTypeBuilder<SOAT_TECNO> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(90);
        }
    }
}

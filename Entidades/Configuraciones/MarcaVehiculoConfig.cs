using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class MarcaVehiculoConfig : IEntityTypeConfiguration<MarcaVehiculo>
    {
        public void Configure(EntityTypeBuilder<MarcaVehiculo> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(60);
        }
    }
}

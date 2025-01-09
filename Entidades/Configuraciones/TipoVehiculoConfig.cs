using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class TipoVehiculoConfig : IEntityTypeConfiguration<TipoVehiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVehiculo> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(60);
        }
    }
}

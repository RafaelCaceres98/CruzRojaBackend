using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class ModeloVehiculoConfig : IEntityTypeConfiguration<ModeloVehiculo>
    {
        public void Configure(EntityTypeBuilder<ModeloVehiculo> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(60);
        }
    }
}

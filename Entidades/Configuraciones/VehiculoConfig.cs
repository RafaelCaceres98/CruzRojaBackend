using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_CruzRoja.Entidades.Configuraciones
{
    public class VehiculoConfig : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.Property(x => x.Placa).HasMaxLength(10);
            builder.Property(x => x.anio).HasMaxLength(10);
            builder.Property(x => x.Chasis).HasMaxLength(60);
            builder.Property(x => x.Motor).HasMaxLength(60);
            builder.Property(x => x.NumMovil).HasMaxLength(60);
            builder.Property(x => x.Propiedad).HasMaxLength(50);
            builder.Property(x => x.anioRecibidoVehiculo).HasMaxLength(10);
            builder.Property(x => x.Ubicacion).HasMaxLength(80);
            builder.Property(x => x.Esactivo).HasColumnType("BIT");

            // Configuraciones de relaciones con DeleteBehavior.Restrict para evitar cascadas problemáticas
            builder.HasOne(x => x.ModeloVehiculo)
               .WithMany(m => m.Vehiculos)
                .HasForeignKey(x => x.ModeloVehiculoId)
                .OnDelete(DeleteBehavior.NoAction); // Evita eliminaciones en cascada

            builder.HasOne(x => x.MarcaVehiculo)
             .WithMany(m => m.Vehiculos)
              .HasForeignKey(x => x.MarcaVehiculoId)
              .OnDelete(DeleteBehavior.NoAction); // Evita eliminaciones en cascada

            builder.HasOne(x => x.Latoneria)
            .WithMany(m => m.Vehiculos)
             .HasForeignKey(x => x.LatoneriaId)
             .OnDelete(DeleteBehavior.NoAction); // Evita eliminaciones en cascada

            builder.HasOne(x => x.Mecanica)
           .WithMany(m => m.Vehiculos)
            .HasForeignKey(x => x.MecanicaId)
            .OnDelete(DeleteBehavior.NoAction); // Evita eliminaciones en cascada

        }
    }
}

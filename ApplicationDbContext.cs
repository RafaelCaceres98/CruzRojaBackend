using Backend_CruzRoja.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Backend_CruzRoja
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configura EmailSettings como una entidad sin clave primaria
            modelBuilder.Entity<EmailSettings>()
                .HasNoKey()
                .ToTable("EmailSettings"); // Asegúrate de que el nombre de la tabla sea correcto


            modelBuilder.Entity<RegKilometraje>()
.Property(x => x.Fecha)
.HasColumnType("datetime")
.IsRequired();



            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<TipoMantenimiento> TipoMantenimientos => Set<TipoMantenimiento>();
        public DbSet<TECNOMECANICA> TECNOMECANICAs => Set<TECNOMECANICA>();
        public DbSet<SOAT_TECNO> SOAT_TECNOs => Set<SOAT_TECNO>();
        public DbSet<SOAT> SOATs => Set<SOAT>();
        public DbSet<RolUsuario> RolUsuarios => Set<RolUsuario>();
        public DbSet<ModeloVehiculo> ModeloVehiculos => Set<ModeloVehiculo>();
        public DbSet<Mecanica> Mecanicas => Set<Mecanica>();
        public DbSet<MarcaVehiculo> MarcaVehiculos => Set<MarcaVehiculo>();
        public DbSet<Mantenimiento> Mantenimientos => Set<Mantenimiento>();
        public DbSet<Latoneria> Latonerias => Set<Latoneria>();
        public DbSet<HojadeVida> HojadeVidas => Set<HojadeVida>();
        public DbSet<EstadoUsuario> EstadoUsuarios => Set<EstadoUsuario>();

        public DbSet<EstadoConductor> EstadoConductores => Set<EstadoConductor>();
        public DbSet<DetallePeriodicidad>  DetallePeriodicidades => Set<DetallePeriodicidad>();
        public DbSet<Conductor>  Conductores => Set<Conductor>();
        public DbSet<CategoriaComprasYServicios>   CategoriaComprasYServicios => Set<CategoriaComprasYServicios>();

        public DbSet<TipoRecorrido> TipoRecorridos => Set<TipoRecorrido>();

        public DbSet<TipoVehiculo> TipoVehiculos => Set<TipoVehiculo>();

        public DbSet<Proyecto> Proyectos => Set<Proyecto>();
        public DbSet<EmailSettings> email => Set<EmailSettings>();

        public DbSet<RegKilometraje> RegKilometrajes => Set<RegKilometraje>();

        public DbSet<TokenRecuperacion> TokensRecuperacion { get; set; }




    }
}


namespace Backend_CruzRoja.Entidades
{
    public class HojadeVida
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = default!;

        public int CategoriaComprasYServiciosId { get; set; }
        public CategoriaComprasYServicios CategoriaComprasYServicios { get; set; } = default!;

        public string Descripcion { get; set; } = default!;

        public int TipoMantenimientoId { get; set; }
        public TipoMantenimiento TipoMantenimiento { get; set; } = default!;

        public string KilometrajeActual { get; set; } = default!;
        public string KIlometrajeDeCierre { get; set; } = default!;
        public DateTime Fecha { get; set; } = default!;
        public string ProveedorDeServicio { get; set; } = default!;
        public string NumFactura { get; set; } = default!;
        public Double ValorPagado { get; set; } = default!;

        public int ConductorId { get; set; } 
        public Conductor Conductor { get; set; } = default!;

        public string Observaciones { get; set; } = default!;
    }

}

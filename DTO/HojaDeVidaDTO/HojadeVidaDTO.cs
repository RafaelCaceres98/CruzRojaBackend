using Backend_CruzRoja.Entidades;

namespace Backend_CruzRoja.DTO.HojaDeVidaDTO
{
    public class HojadeVidaDTO
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
       

        public int CategoriaComprasYServiciosId { get; set; }
    

        public string Descripcion { get; set; } = default!;

        public int TipoMantenimientoId { get; set; }
      
        public string KilometrajeActual { get; set; } = default!;
        public string KIlometrajeDeCierre { get; set; } = default!;
        public DateTime Fecha { get; set; } = default!;
        public string ProveedorDeServicio { get; set; } = default!;
        public string NumFactura { get; set; } = default!;
        public Double ValorPagado { get; set; } = default!;

        public int ConductorId { get; set; }

        public string Observaciones { get; set; } = default!;
    }
}

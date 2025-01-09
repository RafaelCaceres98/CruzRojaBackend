namespace Backend_CruzRoja.DTO.MantenimientoDTO
{
    public class MantenimientoUpdateDTO
    {
        public int Id { get; set; }

        public int VehiculoId { get; set; }

        public int DetallePeriodicidadId { get; set; }

        // public DateTime FechaSolicitud { get; set; } = default!;
       // public int TiempoDias { get; set; } = default!;
        public DateTime FechaVencimiento { get; set; } = default!;

        public int KilometrajeActual { get; set; } = default!;
        public int KilometrajeParaMantenimiento { get; set; } = default!;

        public int PeriodicidadKilometraje { get; set; }

        public string PeriodicidadXTiempo { get; set; } = default!;

        public int ConductorId { get; set; }
    }
}

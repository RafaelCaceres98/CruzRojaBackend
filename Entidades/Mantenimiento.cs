namespace Backend_CruzRoja.Entidades
{
    public class Mantenimiento
    {
        public int Id { get; set; }

        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = default!;

        public int DetallePeriodicidadId { get; set; }
        public DetallePeriodicidad DetallePeriodicidad { get; set; } = default!;

        public DateTime FechaSolicitud { get; set; } = default!;
        public DateTime FechaVencimiento { get; set; } = default!;
        public int TiempoDias { get; set; } = default!;
        //porcentaje vencimiento

        public int KilometrajeActual { get; set; } = default!;
        public int KilometrajeParaMantenimiento { get; set; } = default!;

        public int PeriodicidadKilometraje { get; set; } 

        public string PeriodicidadXTiempo { get; set; } = default!;

        public int ConductorId { get; set; }
        public Conductor Conductor { get; set; } = default!;
    }
}

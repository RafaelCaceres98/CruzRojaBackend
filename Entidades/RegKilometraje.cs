namespace Backend_CruzRoja.Entidades
{
    public class RegKilometraje
    {
        public int Id { get; set; }

        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = default!;

        public int ConductorId { get; set; }
        public Conductor Conductor { get; set; } = default!;

        public string NumeroDocumento { get; set; } = default!;
        public string Kilometraje { get; set; } = default!;
        public DateTime FechaKilometraje { get; set; } // Fecha y hora del kilometraje de salida

        public string Kilometrajellegada { get; set; } = default!;
        public DateTime? FechaKilometrajeLlegada { get; set; } // Fecha y hora del kilometraje de llegada, nullable

        public DateTime Fecha { get; set; } = default!;

        public int ProyectoId { get; set; }

        public Proyecto Proyecto { get; set; } = default!;

        public string Novedades { get; set; } = default!;

        public string Descripcion { get; set; } = default!;

        public byte[] Foto { get; set; }



    }
}

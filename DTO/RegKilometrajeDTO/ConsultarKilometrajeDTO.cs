namespace Backend_CruzRoja.DTO.RegKilometrajeDTO
{
    public class ConsultarKilometrajeDTO
    {
        public int Id { get; set; }

        public int VehiculoId { get; set; }

        public string NumeroDocumento { get; set; } = default!;
        public int ConductorId { get; set; }

        public string Kilometraje { get; set; } = default!;

        public string Kilometrajellegada { get; set; } = default!;

        public DateTime FechaKilometraje { get; set; } // Fecha y hora del kilometraje de salida
        public DateTime FechaKilometrajeLlegada { get; set; } // Nullable para permitir valor nulo

        public DateTime Fecha { get; set; } = default!;

        public int ProyectoId { get; set; }

        public string Novedades { get; set; } = default!;

        public string Descripcion { get; set; } = default!;

        
    }
}

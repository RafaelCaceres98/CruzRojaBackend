namespace Backend_CruzRoja.DTO.ConductorDTO
{
    public class ConductorConsultaDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public string NumeroIdentificacion { get; set; } = default!;

        public string TipoLicencia { get; set; } = default!;

        public string Categoria { get; set; } = default!;

        public int EstadoConductoresId { get; set; }


    }
}

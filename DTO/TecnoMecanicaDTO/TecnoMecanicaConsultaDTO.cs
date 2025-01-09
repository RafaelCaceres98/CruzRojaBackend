namespace Backend_CruzRoja.DTO.TecnoMecanicaDTO
{
    public class TecnoMecanicaConsultaDTO
    {
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaVencimiento { get; set; }
        //tiempo dias 
        // porcentaje vencimiento
        public string Periodicidad { get; set; } = string.Empty;
    }
}

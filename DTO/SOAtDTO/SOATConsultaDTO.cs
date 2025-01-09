namespace Backend_CruzRoja.DTO.SOAtDTO
{
    public class SOATConsultaDTO
    {
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaVencimiento { get; set; }
        //tiempo dias 
        // porcentaje vencimiento
        public string Periodicidad { get; set; } = string.Empty;
    }
}

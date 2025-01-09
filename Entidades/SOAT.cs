namespace Backend_CruzRoja.Entidades
{
    public class SOAT
    {
        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaVencimiento { get; set; }
        //tiempo dias 
        // porcentaje vencimiento
        public string Periodicidad { get; set; } = string.Empty;

    }
}

namespace Backend_CruzRoja.Entidades
{
    public class Conductor
    {
       public int Id { get; set; }
        public string Nombres { get; set; } = default!;
       public string Apellidos { get; set; } = default!;
        public string NumeroIdentificacion { get; set; } = default!; // Nueva propiedad añadida

        public string TipoLicencia { get; set; } = default!;

        public string Categoria { get; set; } = default!;

        public int EstadoConductoresId { get; set; }

        public  EstadoConductor EstadoConductores { get; set; } = default!;



        public List<HojadeVida>  HojadeVidas { get; set; } = new List<HojadeVida>();

        public List<Mantenimiento> Mantenimientoss { get; set; } = new List<Mantenimiento>();

        public List<RegKilometraje> RegKilometrajes { get; set; } = new List<RegKilometraje>();
    }
}

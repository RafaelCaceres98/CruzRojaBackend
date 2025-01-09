namespace Backend_CruzRoja.Entidades
{
    public class Proyecto
    {
        public int Id { get; set; } //llave primaria
        public string Descripcion { get; set; } = default!;

        public List<RegKilometraje> RegKilometrajes { get; set; } = new List<RegKilometraje>();

    }
}

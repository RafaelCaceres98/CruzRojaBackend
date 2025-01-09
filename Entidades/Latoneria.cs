namespace Backend_CruzRoja.Entidades
{
    public class Latoneria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;

        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}

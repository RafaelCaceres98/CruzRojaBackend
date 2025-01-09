namespace Backend_CruzRoja.Entidades
{
    public class MarcaVehiculo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;

        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}

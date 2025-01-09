namespace Backend_CruzRoja.Entidades
{
    public class ModeloVehiculo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;

        public int MarcaVehiculoId { get; set; }
        public MarcaVehiculo MarcaVehiculo { get; set; } = default!;

        public List<Vehiculo>  Vehiculos { get; set; } = new List<Vehiculo>();
    }
}

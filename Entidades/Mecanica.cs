namespace Backend_CruzRoja.Entidades
{
    public class Mecanica
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    }
}

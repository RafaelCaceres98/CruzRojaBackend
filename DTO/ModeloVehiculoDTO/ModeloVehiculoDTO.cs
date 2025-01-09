namespace Backend_CruzRoja.DTO.ModeloVehiculoDTO
{
    public class ModeloVehiculoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public int MarcaVehiculoId { get; set; }
    }
}

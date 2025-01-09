namespace Backend_CruzRoja.Entidades
{
    public class SOAT_TECNO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = default!;

        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = default!;

        public List<SOAT> SOATs { get; set; } = new List<SOAT>();
        public List<TECNOMECANICA> TECNOMECANICAs { get; set; } = new List<TECNOMECANICA>();
    }
}

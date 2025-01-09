namespace Backend_CruzRoja.DTO.VehiculoDTO
{
    public class ConsultaVehiculoDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; } = default!;
        public string anio { get; set; }
        public string Chasis { get; set; } = default!;
        public string Motor { get; set; } = default!;
        public string NumMovil { get; set; } = default!;
        public string Propiedad { get; set; } = default!;
        public string anioRecibidoVehiculo { get; set; }
        public string Ubicacion { get; set; } = default!;
        public Boolean Esactivo { get; set; } = default!; // is True or False


        public int TipoVehiculoId { get; set; }
        public int MarcaVehiculoId { get; set; }
        public int ModeloVehiculoId { get; set; }
        public int LatoneriaId { get; set; }
        public int MecanicaId { get; set; }
    }
}

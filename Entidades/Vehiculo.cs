namespace Backend_CruzRoja.Entidades
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; } = default!;
        public string anio { get; set; }
        public string Chasis { get; set; } = default!;
        public string Motor { get; set; } = default!;
        public string NumMovil { get; set; } = default!;
        public string Propiedad { get; set; } = default!;
        public string anioRecibidoVehiculo { get; set; } = default!;
        public string Ubicacion { get; set; } = default!;
       public Boolean Esactivo { get; set; } = default!; // is True or False

        public int MarcaVehiculoId { get; set; }
        public MarcaVehiculo MarcaVehiculo { get; set; } = default!;

        public int ModeloVehiculoId { get; set; }
        public ModeloVehiculo ModeloVehiculo { get; set; } = default!;

        public int LatoneriaId { get; set; }
        public Latoneria Latoneria { get; set; } = default!;

        public int MecanicaId { get; set; }
        public Mecanica Mecanica { get; set; } = default!;

        public int TipoVehiculoId { get; set; }
        public TipoVehiculo TipoVehiculo  { get; set; } = default!;

        public List<RegKilometraje> RegKilometrajes { get; set; } = new List<RegKilometraje>();


    }
}

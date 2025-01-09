namespace Backend_CruzRoja.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = default!;
        public string clave { get; set; } = default!;

        public string CorreoElectronico { get; set; } = default!; // Nuevo campo

        public int EstadoUsuarioId { get; set; }
        public EstadoUsuario EstadoUsuario { get; set; } = default!;

        public int RolUsuarioId { get; set; }
        public RolUsuario RolUsuario { get; set;} = default!;

    }
}

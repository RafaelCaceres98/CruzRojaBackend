namespace Backend_CruzRoja.DTO.UsuariosDTO
{
    public class UsuarioUpdateDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = default!;
        public string clave { get; set; } = default!;

        public string CorreoElectronico { get; set; } = default!; // Nuevo campo
        public int EstadoUsuarioId { get; set; }
        public int RolUsuarioId { get; set; }
    }
}

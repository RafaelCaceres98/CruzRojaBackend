namespace Backend_CruzRoja.Entidades
{
    public class TokenRecuperacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; } = default!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}

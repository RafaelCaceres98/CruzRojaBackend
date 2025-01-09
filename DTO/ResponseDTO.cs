namespace Backend_CruzRoja.DTO
{
    public class ResponseDTO
    {
        public object Data { get; set; }
        public string Mensaje { get; set; }
        public string Token { get; set; }


        public static implicit operator bool(ResponseDTO v)
        {
            throw new NotImplementedException();
        }
    }
}

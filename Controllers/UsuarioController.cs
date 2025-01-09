using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly UsuariosAppService usuariosAppService;

        public UsuarioController(UsuariosAppService  usuariosAppService)
        {
            this.usuariosAppService = usuariosAppService;
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            return Ok(await usuariosAppService.Post(usuarioCreacionDTO));
        }

        [HttpPut("{id}")] // actualiza un usuario
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioUpdateDTO usuarioUpdateDTO)
        {
            return Ok(await usuariosAppService.Put(id, usuarioUpdateDTO));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            return Ok(await usuariosAppService.Authenticate(loginDTO));

        }

        [HttpGet("ListaUsuarios")]
        public async Task<IActionResult> Get()
        {
            return Ok(await usuariosAppService.Get());
        }

        //// Nuevo método para recuperar contraseña
        //[HttpPost("RecuperarContrasena")]
        //public async Task<IActionResult> RecuperarContrasena([FromBody] RecuperarContrasenaDTO recuperarContrasenaDTO)
        //{
        //    var response = await usuariosAppService.RecuperarContrasena(recuperarContrasenaDTO);
        //    if (response.Mensaje == "Se ha enviado un correo de recuperación.")
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response);
        //}


        //[HttpPost("RecuperarContrasena")]
        //public async Task<IActionResult> RecuperarContrasena([FromBody] RecuperarContrasenaDTO recuperarContrasenaDTO)
        //{
        //    // Llama al servicio para recuperar la contraseña
        //    var response = await usuariosAppService.RecuperarContrasena(recuperarContrasenaDTO);

        //    // Verifica si se ha enviado el correo
        //    if (response.Mensaje == "Se ha enviado un correo de recuperación.")
        //    {
        //        return Ok(response); // Respuesta 200 OK
        //    }

        //    // Si el mensaje indica que el correo no está asociado, devuelve un 404
        //    if (response.Mensaje == "El correo electrónico no está asociado a ningún usuario.")
        //    {
        //        return NotFound(new { mensaje = response.Mensaje });
        //    }

        //    // Para cualquier otro tipo de error, puedes devolver un 400 Bad Request
        //    return BadRequest(response);
        //}

        [HttpPost("RecuperarContrasena")]
        public async Task<IActionResult> RecuperarContrasena([FromBody] RecuperarContrasenaDTO recuperarContrasenaDTO)
        {

            // Validar que el correo electrónico no esté vacío
            if (string.IsNullOrEmpty(recuperarContrasenaDTO.CorreoElectronico))
            {
                return Ok(new { mensaje = "El correo electrónico no puede estar vacío.", success = false });
            }

            // Llama al servicio para recuperar la contraseña
            var response = await usuariosAppService.RecuperarContrasena(recuperarContrasenaDTO);

            // Verifica si se ha enviado el correo
            if (response.Mensaje == "Se ha enviado un correo de recuperación.")
            {
                return Ok(response); // Respuesta 200 OK
            }

            // Si el correo no está asociado, devuelve un mensaje en el cuerpo con un código 200
            if (response.Mensaje == "El correo electrónico no pertenece a este usuario.")
            {
                return Ok(new { mensaje = response.Mensaje, success = false });
            }

            // Para cualquier otro tipo de error, puedes devolver un 200 OK con un mensaje genérico
            return Ok(new { mensaje = "El correo electrónico no pertenece a este usuario", success = false });
        }
   



        [HttpPost("cambiar-contrasena")]
        public async Task<ActionResult<ResponseDTO>> CambiarContrasena([FromBody] CambiarContrasenaDTO cambiarContrasenaDTO)
        {
            var response = await usuariosAppService.CambiarContrasena(cambiarContrasenaDTO);
            return Ok(response);
        }

    }
}

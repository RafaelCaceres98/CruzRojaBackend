using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO.ConductorDTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ConductorController : ControllerBase
    {
        private readonly ConductorAppService conductorAppService;

        public ConductorController(ConductorAppService conductorAppService)
        {
            this.conductorAppService = conductorAppService;
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] ConductorConsultaDTO  conductorConsultaDTO)
        {
            return Ok(await conductorAppService.Post(conductorConsultaDTO));
        }

        [HttpGet("ListaConductores")]
        public async Task<IActionResult> Get()
        {
            return Ok(await conductorAppService.Get());
        }

        [HttpDelete("Eliminar/{numeroIdentificacion}")] // Eliminando un registro
        public async Task<IActionResult> Delete(string numeroIdentificacion)
        {
            var response = await conductorAppService.Delete(numeroIdentificacion);

            return Ok(response); // Devuelve 200 con el mensaje, sin importar si se encontró el conductor o no
        }

        [HttpPut("Actualizar/{id}")] // Actualizando un registro
        public async Task<IActionResult> Update(int id, [FromBody] ConductorConsultaDTO conductorConsultaDTO)
        {
            var response = await conductorAppService.Update(id, conductorConsultaDTO);

            return Ok(response); // Devuelve 200 con el mensaje de éxito o error
        }


    }
}

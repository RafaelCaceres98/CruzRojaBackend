using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO.DetallePeriocidadDTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DetallePeriocidadController : ControllerBase
    {
        private readonly DetallePeriodicidadAppService detallePeriodicidadAppService;

        public DetallePeriocidadController(DetallePeriodicidadAppService detallePeriodicidadAppService)
        {
            this.detallePeriodicidadAppService = detallePeriodicidadAppService;
        }


        [HttpGet("Lista")]
        public async Task<IActionResult> Get()
        {
            return Ok(await detallePeriodicidadAppService.Get());
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] DetallePericiodiadDTO  detallePericiodiadDTO)
        {
            return Ok(await detallePeriodicidadAppService.Post(detallePericiodiadDTO));
        }

        [HttpDelete("{id}")] // Elimina
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await detallePeriodicidadAppService.Eliminar(id));

        }
    }
}

using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Backend_CruzRoja.DTO.VehiculoDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VehiculoController : ControllerBase
    {
        private readonly VehiculoAppService vehiculoAppService;

        public VehiculoController(VehiculoAppService vehiculoAppService)
        {
            this.vehiculoAppService = vehiculoAppService;
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] CrearVehiculoDTO  crearVehiculoDTO)
        {
            return Ok(await vehiculoAppService.Post(crearVehiculoDTO));
        }

        [HttpPut("{id}")] // actualiza un vehiculo
        public async Task<IActionResult> Put(int id, [FromBody] ConsultaVehiculoDTO  consultaVehiculoDTO)
        {
            return Ok(await vehiculoAppService.Put(id, consultaVehiculoDTO));
        }

        [HttpGet("ListaVehiculos")]
        public async Task<IActionResult> Get()
        {
            return Ok(await vehiculoAppService.Get());
        }


        // para el filtro de busqueda
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<CrearVehiculoDTO>>> Buscar(string busqueda)
        {
            return Ok(await vehiculoAppService.Buscar(busqueda));
        }
    }
}

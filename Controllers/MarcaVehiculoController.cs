using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO.MarcaVehiculoDTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MarcaVehiculoController : ControllerBase
    {
        private readonly MarcaVehiculoAppService marcaVehiculoAppService;

        public MarcaVehiculoController(MarcaVehiculoAppService marcaVehiculoAppService)
        {
            this.marcaVehiculoAppService = marcaVehiculoAppService;
        }


        [HttpGet("ListaMarcaVehiculo")]
        public async Task<IActionResult> Get()
        {
            return Ok(await marcaVehiculoAppService.Get());
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] MarcaVehiculoConsultaDTO  marcaVehiculoConsultaDTO)
        {
            return Ok(await marcaVehiculoAppService.Post(marcaVehiculoConsultaDTO));
        }
    }
}

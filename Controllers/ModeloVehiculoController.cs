using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO.MarcaVehiculoDTO;
using Backend_CruzRoja.DTO.ModeloVehiculoDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ModeloVehiculoController : ControllerBase
    {
        private readonly ModeloVehiculoAppService modeloVehiculoAppService;

        public ModeloVehiculoController(ModeloVehiculoAppService modeloVehiculoAppService)
        {
            this.modeloVehiculoAppService = modeloVehiculoAppService;
        }

        [HttpGet("ListaModeloVehiculo")]
        public async Task<IActionResult> Get()
        {
            return Ok(await modeloVehiculoAppService.Get());
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] ModeloVehiculoDTO  modeloVehiculoDTO)
        {
            return Ok(await modeloVehiculoAppService.Post(modeloVehiculoDTO));
        }

        [HttpGet("{marcaVehiculoId}")]
        public async Task<IActionResult> GetMunicipioXDepartamento(int marcaVehiculoId)
        {
            return Ok(await modeloVehiculoAppService.GetModelosPorMarcaId(marcaVehiculoId));
        }
    }
}

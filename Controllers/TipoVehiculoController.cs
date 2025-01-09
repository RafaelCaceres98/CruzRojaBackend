using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class TipoVehiculoController : ControllerBase
    {
        private readonly TipoVehiculoAppService tipoVehiculoAppService;

        public TipoVehiculoController(TipoVehiculoAppService tipoVehiculoAppService)
        {
            this.tipoVehiculoAppService = tipoVehiculoAppService;
        }

        [HttpGet("ListaTipoVehiculos")]
        public async Task<IActionResult> Get()
        {
            return Ok(await tipoVehiculoAppService.Get());
        }
    }
}

using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TipoMantenimientoController : ControllerBase
    {
        private readonly TipoMantenimientoAppService tipoMantenimientoAppService;

        public TipoMantenimientoController(TipoMantenimientoAppService tipoMantenimientoAppService)
        {
            this.tipoMantenimientoAppService = tipoMantenimientoAppService;
        }

        [HttpGet("ListaTipoMantenimiento")]
        public async Task<IActionResult> Get()
        {
            return Ok(await tipoMantenimientoAppService.Get());
        }
    }
}

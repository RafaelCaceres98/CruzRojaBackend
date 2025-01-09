using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MecanicaController : ControllerBase
    {
        private readonly MecanicaAppService mecanicaAppService;

        public MecanicaController(MecanicaAppService mecanicaAppService)
        {
            this.mecanicaAppService = mecanicaAppService;
        }

        [HttpGet("ListaMecanica")]
        public async Task<IActionResult> Get()
        {
            return Ok(await mecanicaAppService.Get());
        }
    }
}

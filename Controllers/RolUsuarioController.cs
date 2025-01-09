using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RolUsuarioController : ControllerBase
    {
        private readonly RolUsuarioAppService rolUsuarioAppService;

        public RolUsuarioController(RolUsuarioAppService rolUsuarioAppService)
        {
            this.rolUsuarioAppService = rolUsuarioAppService;
        }

        [HttpGet("ListaRolUsuarios")]
        public async Task<IActionResult> Get()
        {
            return Ok(await rolUsuarioAppService.Get());
        }

    }
}

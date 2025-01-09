using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EstadoUsuarioController : ControllerBase
    {
        private readonly EstadoUsuarioAppService estadoUsuarioAppService;

        public EstadoUsuarioController(EstadoUsuarioAppService estadoUsuarioAppService)
        {
            this.estadoUsuarioAppService = estadoUsuarioAppService;
        }

        [HttpGet("ListaEstadoUsuarios")]
        public async Task<IActionResult> Get()
        {
            return Ok(await estadoUsuarioAppService.Get());
        }
    }
}

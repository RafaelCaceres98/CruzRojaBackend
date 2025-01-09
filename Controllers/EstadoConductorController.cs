using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoConductorController : ControllerBase
    {
        private readonly EstadoConductoresAppService estadoConductoresAppService;

        public EstadoConductorController(EstadoConductoresAppService estadoConductoresAppService)
        {
            this.estadoConductoresAppService = estadoConductoresAppService;
        }


        [HttpGet("ListaEstadoConductores")]
        public async Task<IActionResult> Get()
        {
            return Ok(await estadoConductoresAppService.Get());
        }
    }
}

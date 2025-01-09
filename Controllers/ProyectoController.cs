using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    public class ProyectoController: ControllerBase
    {
        private readonly ProyectoAppService ProyectoAppService;

        public ProyectoController(ProyectoAppService proyectoAppService)
        {
            this.ProyectoAppService = proyectoAppService;
        }

        [HttpGet("ListaTipoProyecto")]
        public async Task<IActionResult> Get()
        {
            return Ok(await ProyectoAppService.Get());
        }
    }
}

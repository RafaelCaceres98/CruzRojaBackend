using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoComprasYServiciosController : ControllerBase
    {
        private readonly CategoComprasYServiciosAppService categoComprasYServiciosAppService;

        public CategoComprasYServiciosController(CategoComprasYServiciosAppService categoComprasYServiciosAppService)
        {
            this.categoComprasYServiciosAppService = categoComprasYServiciosAppService;
        }

        [HttpGet("ListaCategComprasServicios")]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoComprasYServiciosAppService.Get());
        }
    }
}

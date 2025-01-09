using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LatoneriaController : ControllerBase
    {
        private readonly LatoneriaAppService latoneriaAppService;

        public LatoneriaController(LatoneriaAppService latoneriaAppService)
        {
            this.latoneriaAppService = latoneriaAppService;
        }

        [HttpGet("ListaLatoneria")]
        public async Task<IActionResult> Get()
        {
            return Ok(await latoneriaAppService.Get());
        }
    }
}

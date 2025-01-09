using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    public class TipoRecorridoController : ControllerBase
    {
        private readonly TipoRecorridoAppService tipoRecorridoAppService;


      public TipoRecorridoController(TipoRecorridoAppService tipoRecorridoAppService)
        {
            this.tipoRecorridoAppService = tipoRecorridoAppService;
        }

        [HttpGet("ListaTipoRecorrido")]
        public async Task<IActionResult> Get()
        {
            return Ok(await tipoRecorridoAppService.Get());
        }
    }
}

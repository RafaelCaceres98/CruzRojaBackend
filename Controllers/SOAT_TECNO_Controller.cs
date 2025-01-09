using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO.SOAT_TECNO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SOAT_TECNO_Controller : ControllerBase
    {
        private readonly SOAT_TECNO_AppService sOAT_TECNO_AppService;

        public SOAT_TECNO_Controller(SOAT_TECNO_AppService sOAT_TECNO_AppService)
        {
            this.sOAT_TECNO_AppService = sOAT_TECNO_AppService;
        }

        //para crear una nueva soicitud con su detalle
        [HttpPost("Crear")]
        public async Task<IActionResult> Post([FromBody] SOAtTECNOCreacionDTO  sOAtTECNOCreacionDTO)
        {
            return Ok(await sOAT_TECNO_AppService.Post(sOAtTECNOCreacionDTO));
        }

        [HttpGet("ListaSOAT_TECNO")]
        public async Task<IActionResult> Get()
        {
            return Ok(await sOAT_TECNO_AppService.Get());
        }

    }
}

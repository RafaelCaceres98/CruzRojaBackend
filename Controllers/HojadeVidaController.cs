using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO.ConductorDTO;
using Backend_CruzRoja.DTO.HojaDeVidaDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HojadeVidaController : ControllerBase
    {
        private readonly HojadeVidaAppService hojadeVidaAppService;

        public HojadeVidaController(HojadeVidaAppService hojadeVidaAppService)
        {
            this.hojadeVidaAppService = hojadeVidaAppService;
        }



        [HttpGet("ListaHojasDeVida")]
        public async Task<IActionResult> Get()
        {
            return Ok(await hojadeVidaAppService.Get());
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] HojadeVidaDTO  hojadeVidaDTO)
        {
            return Ok(await hojadeVidaAppService.Post(hojadeVidaDTO));
        }


    }
}

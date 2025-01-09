using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.DetallePeriocidadDTO;
using Backend_CruzRoja.DTO.MantenimientoDTO;
using Backend_CruzRoja.DTO.VehiculoDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MantenimientoController : ControllerBase
    {
        private readonly MantenimientoAppService mantenimientoAppService;

        public MantenimientoController(MantenimientoAppService mantenimientoAppService)
        {
            this.mantenimientoAppService = mantenimientoAppService;
        }


        [HttpGet("ListaMantenimiento")]
        public async Task<IActionResult> Get()
        {
            return Ok(await mantenimientoAppService.Get());
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromBody] MantenimientoDTO  mantenimientoDTO)
        {
            return Ok(await mantenimientoAppService.Post(mantenimientoDTO));
        }

        [HttpDelete("{id}")] // Elimina
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mantenimientoAppService.Eliminar(id));

        }

        [HttpPut("{id}")] // actualiza 
        public async Task<IActionResult> Put(int id, [FromBody] MantenimientoUpdateDTO  mantenimientoUpdateDTO)
        {
            return Ok(await mantenimientoAppService.Actualizar(id,  mantenimientoUpdateDTO));
        }

        [HttpGet("Mantenimiento/{id}")]
        public async Task<IActionResult> GetFacturasTransaccion(int id)
        {
            return Ok(await mantenimientoAppService.GetMantenimientoByIdSelective(id));
        }



        // Endpoint para consultar el vehículo con más mantenimientos por mes
        [HttpGet("mantenimientoporMes")]
        public async Task<ActionResult<ResponseDTO>> GetVehiculoConMasMantenimientosPorMes(int mes, int anio)
        {
            var response = await mantenimientoAppService.GetVehiculoConMasMantenimientosPorMes(mes, anio);
            return Ok(response);
        }


        [HttpGet("conductores")]
        public async Task<ActionResult<ResponseDTO>> GetMantenimientosPorConductor()
        {
            var result = await mantenimientoAppService.GetMantenimientosPorConductor();
            return Ok(result);
        }
    }
}

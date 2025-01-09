using Backend_CruzRoja.AppService;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.RegKilometrajeDTO;
using Backend_CruzRoja.DTO.VehiculoDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RegKilometrajeController: ControllerBase
    {
        private readonly RegKilometrajeAppService regKilometrajeAppService;
        private readonly ApplicationDbContext _context;

        public RegKilometrajeController(RegKilometrajeAppService regKilometrajeAppService, ApplicationDbContext context)
        {
            this.regKilometrajeAppService = regKilometrajeAppService;
            _context = context;
        }

        [HttpPost("Crear")] //creando un nuevo registro
        public async Task<IActionResult> Post([FromForm] CrearKilometrajeDTO crearKilometrajeDTO, IFormFile foto)
        {
            if (crearKilometrajeDTO == null) 
            {
                return BadRequest("No se recibieron datos.");
            }

            var result = await regKilometrajeAppService.Post(crearKilometrajeDTO, foto);
            return Ok(result);

        }

        [HttpGet("GetFoto/{id}")]
        public async Task<IActionResult> GetFoto(int id)
        {
            var accesorio = await _context.RegKilometrajes.FindAsync(id);
            if (accesorio == null || accesorio.Foto == null)
            {
                return NotFound();
            }

            return File(accesorio.Foto, "image/jpeg"); // Ajusta el tipo de contenido según el formato de tu imagen
        }


        [HttpPut("{id}")] // actualiza un vehiculo
        public async Task<IActionResult> Put(int id, [FromBody] ConsultarKilometrajeDTO consultaKilometrajeDTO)
        {
            return Ok(await regKilometrajeAppService.Put(id, consultaKilometrajeDTO));
        }

        [HttpGet("ListaRegistrosKilome")]
        public async Task<IActionResult> Get()
        {
            return Ok(await regKilometrajeAppService.Get());
        }



        // para el filtro de busqueda
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<CrearKilometrajeDTO>>> Buscar(string busqueda)
        {
            return Ok(await regKilometrajeAppService.Buscar(busqueda));
        }


        // Método para obtener kilometrajes por rango de fechas
        [HttpGet("kilometrajes/rango")]
        public async Task<IActionResult> GetKilometrajePorRangoFechas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var kilometrajes = await regKilometrajeAppService.GetKilometrajePorRangoFechas(fechaInicio, fechaFin);

            if (kilometrajes == null || !kilometrajes.Any())
            {
                return Ok(new List<ConsultarKilometrajeDTO1>());  // Devuelve una lista vacía
            }

            return Ok(kilometrajes);
        }
    }



}




using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.RegKilometrajeDTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class RegKilometrajeAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RegKilometrajeAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Consulta todos los registros
        public async Task<IEnumerable<ConsultarKilometrajeDTO>> Get()
        {
            return await context.RegKilometrajes
                .ProjectTo<ConsultarKilometrajeDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // Crea un nuevo registro
        public async Task<ResponseDTO> Post(CrearKilometrajeDTO crearKilometrajeDTO, IFormFile foto)
        {
            var responseDTO = new ResponseDTO();

            if (await context.RegKilometrajes.AnyAsync(c => c.NumeroDocumento == crearKilometrajeDTO.NumeroDocumento))
            {
                responseDTO.Mensaje = "Ya existe un Kilometraje con el mismo número de documento";
                return responseDTO;
            }

            byte[] fotoBytes = null;

            if (foto != null && foto.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await foto.CopyToAsync(memoryStream);
                    fotoBytes = memoryStream.ToArray(); // Convertir el archivo a un arreglo de bytes
                }
            }

            RegKilometraje kilometraje = new RegKilometraje
            {
                Kilometraje = crearKilometrajeDTO.Kilometraje,
                FechaKilometraje = DateTime.Now,
                Kilometrajellegada = crearKilometrajeDTO.Kilometrajellegada, 
                FechaKilometrajeLlegada = DateTime.Now, 
                Fecha = DateTime.Now,
                NumeroDocumento = crearKilometrajeDTO.NumeroDocumento,
                Novedades = crearKilometrajeDTO.Novedades,
                Descripcion = crearKilometrajeDTO.Descripcion,
                VehiculoId = crearKilometrajeDTO.VehiculoId,
                ConductorId = crearKilometrajeDTO.ConductorId,
                ProyectoId = crearKilometrajeDTO.ProyectoId,
                Foto = fotoBytes // Almacenar la imagen como un arreglo de bytes
            };

            context.Add(kilometraje);
            await context.SaveChangesAsync();

            responseDTO.Data = mapper.Map<CrearKilometrajeDTO>(kilometraje);
            responseDTO.Mensaje = "Kilometraje creado con éxito.";

            return responseDTO;
        }

        // Realiza búsquedas desde la caja de texto del formulario empresa
        public async Task<IEnumerable<CrearKilometrajeDTO>> Buscar(string busqueda)
        {
            busqueda = busqueda.ToLower();

            return await context.RegKilometrajes
                .Where(s => s.NumeroDocumento.ToLower().Contains(busqueda))
                .Select(perfilempresaDTO => new CrearKilometrajeDTO
                {
                    NumeroDocumento = perfilempresaDTO.NumeroDocumento,
                    Kilometraje = perfilempresaDTO.Kilometraje,
                    Kilometrajellegada = perfilempresaDTO.Kilometrajellegada,
                    Novedades = perfilempresaDTO.Novedades,
                    Descripcion = perfilempresaDTO.Descripcion,
                    VehiculoId = perfilempresaDTO.VehiculoId,
                    ConductorId = perfilempresaDTO.ConductorId,
                    ProyectoId = perfilempresaDTO.ProyectoId,
                })
                .ToListAsync();
        }

        // Actualiza un registro con su ID
        public async Task<ResponseDTO> Put(int id, ConsultarKilometrajeDTO consultarKilometrajeDTO)
        {
            var kilometraje = await context.RegKilometrajes.FindAsync(id);

            if (kilometraje == null)
            {
                return new ResponseDTO
                {
                    Mensaje = "El ID del Kilometraje no existe"
                };
            }

            // Verificar si existe otro registro con el mismo número de documento antes de actualizar
            var existeKilometraje = await context.RegKilometrajes.FirstOrDefaultAsync(c => c.Id != id && c.NumeroDocumento == consultarKilometrajeDTO.NumeroDocumento);
            if (existeKilometraje != null)
            {
                return new ResponseDTO
                {
                    Mensaje = "El número de documento ya está en uso"
                };
            }

            // Actualizar solo los campos necesarios
            kilometraje.Kilometraje = consultarKilometrajeDTO.Kilometraje;
            kilometraje.NumeroDocumento = consultarKilometrajeDTO.NumeroDocumento;
            kilometraje.Novedades = consultarKilometrajeDTO.Novedades;
            kilometraje.Descripcion = consultarKilometrajeDTO.Descripcion;
            kilometraje.VehiculoId = consultarKilometrajeDTO.VehiculoId;
            kilometraje.ConductorId = consultarKilometrajeDTO.ConductorId;
            kilometraje.ProyectoId = consultarKilometrajeDTO.ProyectoId;

            // Si Kilometrajellegada se actualiza, establecer FechaKilometrajeLlegada
            if (!string.IsNullOrEmpty(consultarKilometrajeDTO.Kilometrajellegada) &&
                (kilometraje.Kilometrajellegada != consultarKilometrajeDTO.Kilometrajellegada || kilometraje.FechaKilometrajeLlegada == null))
            {
                kilometraje.Kilometrajellegada = consultarKilometrajeDTO.Kilometrajellegada;
                kilometraje.FechaKilometrajeLlegada = DateTime.Now; // Establecer la fecha y hora de llegada
            }

            context.Update(kilometraje);
            await context.SaveChangesAsync();

            return new ResponseDTO
            {
                Data = consultarKilometrajeDTO
            };
        }


        public async Task<List<ConsultarKilometrajeDTO1>> GetKilometrajePorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return await context.RegKilometrajes
                .Where(k => k.Fecha >= fechaInicio && k.Fecha <= fechaFin)
                .Join(context.Vehiculos, // Suponiendo que esta es tu tabla de vehículos
                    kilometraje => kilometraje.VehiculoId,
                    vehiculo => vehiculo.Id, // Asegúrate de que este sea el campo correcto
                    (kilometraje, vehiculo) => new { kilometraje, vehiculo }) // Crear un objeto anónimo para facilitar el mapeo
                .Select(x => new ConsultarKilometrajeDTO1
                {
                    Id = x.kilometraje.Id,
                    PlacaVehiculo = x.vehiculo.Placa, // Asignar la placa
                    VehiculoId = x.kilometraje.VehiculoId,
                    NumeroDocumento = x.kilometraje.NumeroDocumento,
                    ConductorId = x.kilometraje.ConductorId,
                    Kilometraje = x.kilometraje.Kilometraje,
                    Kilometrajellegada = x.kilometraje.Kilometrajellegada,
                    FechaKilometraje = x.kilometraje.FechaKilometraje,
                    //FechaKilometrajeLlegada = x.kilometraje.FechaKilometrajeLlegada,
                    Fecha = x.kilometraje.Fecha,
                    ProyectoId = x.kilometraje.ProyectoId,
                    Novedades = x.kilometraje.Novedades,
                    Descripcion = x.kilometraje.Descripcion,
                })
                .ToListAsync();
        }






    }
}


using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.ConductorDTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Backend_CruzRoja.DTO.VehiculoDTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class ConductorAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ConductorAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Proyecta todos los regristros
        public async Task<IEnumerable<ConductorConsultaDTO>> Get()
        {
            return await context.Conductores

                .ProjectTo<ConductorConsultaDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        //Creando un nuevo registro
        public async Task<ResponseDTO> Post(ConductorConsultaDTO conductorConsultaDTO)
        {
            var responseDTO = new ResponseDTO();

            if (await context.Conductores.AnyAsync(c => c.NumeroIdentificacion == conductorConsultaDTO.NumeroIdentificacion))
            {
                responseDTO.Mensaje = "Ya existe un Numero de documento registrado, no puede ser igual";
            }
            else
            {
                Conductor conductor = new Conductor
                {
                    Nombres = conductorConsultaDTO.Nombres,
                    Apellidos = conductorConsultaDTO.Apellidos,
                    NumeroIdentificacion = conductorConsultaDTO.NumeroIdentificacion,
                    TipoLicencia = conductorConsultaDTO.TipoLicencia,
                    Categoria = conductorConsultaDTO.Categoria,
                    EstadoConductoresId = conductorConsultaDTO.EstadoConductoresId
                };

                context.Add(conductor);
                await context.SaveChangesAsync();

                responseDTO.Data = mapper.Map<ConductorConsultaDTO>(conductor);
                responseDTO.Mensaje = "Conductor creado con éxito.";
            }

            return responseDTO;
        }


        // Actualizando un registro
        public async Task<ResponseDTO> Update(int id, ConductorConsultaDTO conductorConsultaDTO)
        {
            var responseDTO = new ResponseDTO();

            // Buscar el conductor por su ID
            var conductor = await context.Conductores
                .FirstOrDefaultAsync(c => c.Id == id); // Asegúrate de que 'Id' sea la propiedad correcta

            if (conductor == null)
            {
                responseDTO.Mensaje = "Conductor no encontrado.";
                return responseDTO;
            }

            // Actualizar los campos del conductor
            conductor.Nombres = conductorConsultaDTO.Nombres;
            conductor.Apellidos = conductorConsultaDTO.Apellidos;
            conductor.NumeroIdentificacion = conductorConsultaDTO.NumeroIdentificacion;
            conductor.TipoLicencia = conductorConsultaDTO.TipoLicencia;
            conductor.Categoria = conductorConsultaDTO.Categoria;
            conductor.EstadoConductoresId = conductorConsultaDTO.EstadoConductoresId;

            // Guardar los cambios
            await context.SaveChangesAsync();

            responseDTO.Data = mapper.Map<ConductorConsultaDTO>(conductor);
            responseDTO.Mensaje = "Conductor actualizado con éxito.";
            return responseDTO;
        }




        //Eliminando un registro
        public async Task<ResponseDTO> Delete(string numeroIdentificacion)
        {
            var responseDTO = new ResponseDTO();

            // Buscar el conductor por su número de identificación
            var conductor = await context.Conductores
                .FirstOrDefaultAsync(c => c.NumeroIdentificacion == numeroIdentificacion);

            if (conductor == null)
            {
                responseDTO.Mensaje = "Conductor no encontrado.";
                return responseDTO;
            }

            // Eliminar el conductor
            context.Conductores.Remove(conductor);
            await context.SaveChangesAsync();

            responseDTO.Mensaje = "Conductor eliminado con éxito.";
            return responseDTO;
        }

    }
}

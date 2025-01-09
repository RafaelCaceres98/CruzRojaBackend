using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.DetallePeriocidadDTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class DetallePeriodicidadAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DetallePeriodicidadAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<DetallePericiodiadDTO>> Get()
        {
            return await context.DetallePeriodicidades

                .ProjectTo<DetallePericiodiadDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        //Creando un nuevo registro
        public async Task<ResponseDTO> Post(DetallePericiodiadDTO CreacionDTO)
        {
            var responseDTO = new ResponseDTO();

            if (await context.DetallePeriodicidades.AnyAsync(c => c.Descripcion == CreacionDTO.Descripcion))
            {
                responseDTO.Mensaje = "Ya existe un resgistro igual";
            }
            else
            {

                DetallePeriodicidad  detalle = new DetallePeriodicidad
                {
                    Descripcion = CreacionDTO.Descripcion,
                };

                context.Add(detalle);
                await context.SaveChangesAsync();

                responseDTO.Data = mapper.Map<DetallePericiodiadDTO>(detalle);
                responseDTO.Mensaje = "Se Creo el Registro";
            }

            return responseDTO;
        }

        public async Task<ResponseDTO> Eliminar(int id)
        {
            var responseDTO = new ResponseDTO();

            // Buscar la venta por ID
            var datelle = await context.DetallePeriodicidades.FindAsync(id);
            if (datelle == null)
            {
                responseDTO.Mensaje = "ID no encontrado.";
                return responseDTO;
            }
         
            context.DetallePeriodicidades.Remove(datelle);
            await context.SaveChangesAsync();

            responseDTO.Mensaje = "eliminado correctamente.";
            return responseDTO;
        }




    }
}

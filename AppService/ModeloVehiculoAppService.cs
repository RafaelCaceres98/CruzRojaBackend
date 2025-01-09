using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.MarcaVehiculoDTO;
using Backend_CruzRoja.DTO.ModeloVehiculoDTO;
using Backend_CruzRoja.Entidades;
using Backend_CruzRoja.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class ModeloVehiculoAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ModeloVehiculoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        //consulta todos los registros
        public async Task<IEnumerable<ModeloVehiculoDTO>> Get()
        {
            return await context.ModeloVehiculos

                .ProjectTo<ModeloVehiculoDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }


        //Creando un nuevo registro
        public async Task<ResponseDTO> Post(ModeloVehiculoDTO  modeloVehiculoDTO)
        {
            var responseDTO = new ResponseDTO();

            if (await context.ModeloVehiculos.AnyAsync(c => c.Descripcion == modeloVehiculoDTO.Descripcion))
            {
                responseDTO.Mensaje = "No se permiten modelos repetidos.";
            }
            else
            {
                ModeloVehiculo modeloVehiculo = new ModeloVehiculo
                {
                    Descripcion = modeloVehiculoDTO.Descripcion,
                    MarcaVehiculoId = modeloVehiculoDTO.MarcaVehiculoId,
                };

                context.Add(modeloVehiculo);
                await context.SaveChangesAsync();

                responseDTO.Data = mapper.Map<ModeloVehiculoDTO>(modeloVehiculo);
                responseDTO.Mensaje = "Registro creado con éxito.";
            }

            return responseDTO;
        }

        public async Task<IEnumerable<ModeloVehiculoDTO>> GetModelosPorMarcaId(int marcaVehiculoId)
        {
            
            var resultado = await context.ModeloVehiculos
                .Include(s => s.MarcaVehiculo)
                .Where(s => s.MarcaVehiculoId == marcaVehiculoId)
                .Select(s => new ModeloVehiculoDTO
                {
                    Id = s.Id,
                    Descripcion = s.Descripcion,
                    MarcaVehiculoId = s.MarcaVehiculoId,
                })
                .ToListAsync();

            return resultado;
        }


    }
}

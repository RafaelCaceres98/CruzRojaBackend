using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.MarcaVehiculoDTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class MarcaVehiculoAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MarcaVehiculoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        //consulta todos los registros
        public async Task<IEnumerable<MarcaVehiculoConsultaDTO>> Get()
        {
            return await context.MarcaVehiculos

                .ProjectTo<MarcaVehiculoConsultaDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        //Creando un nuevo registro
        public async Task<ResponseDTO> Post(MarcaVehiculoConsultaDTO  marcaVehiculoConsultaDTO)
        {
            var responseDTO = new ResponseDTO();

            if (await context.MarcaVehiculos.AnyAsync(c => c.Descripcion == marcaVehiculoConsultaDTO.Descripcion))
            {
                responseDTO.Mensaje = "No se permiten marcas repetidas.";
            }
            else
            {
                MarcaVehiculo marca = new MarcaVehiculo
                {
                    Descripcion = marcaVehiculoConsultaDTO.Descripcion,    
                };

                context.Add(marca);
                await context.SaveChangesAsync();

                responseDTO.Data = mapper.Map<MarcaVehiculoConsultaDTO>(marca);
                responseDTO.Mensaje = "Registro creado con éxito.";
            }

            return responseDTO;
        }

    }
}

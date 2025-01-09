using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.TipoMantenimientoDTO;
using Backend_CruzRoja.DTO.TipoVehiculoDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class TipoVehiculoAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoVehiculoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<ConsultaTipoVehiculoDTO>> Get()
        {
            return await context.TipoVehiculos

                .ProjectTo<ConsultaTipoVehiculoDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

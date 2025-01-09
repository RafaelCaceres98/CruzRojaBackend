using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.TipoMantenimientoDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class TipoMantenimientoAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoMantenimientoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<ConsultaTipoMantenimientoDTO>> Get()
        {
            return await context.TipoMantenimientos

                .ProjectTo<ConsultaTipoMantenimientoDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

    }
}

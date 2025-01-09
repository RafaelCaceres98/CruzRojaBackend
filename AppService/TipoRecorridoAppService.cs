using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_CruzRoja.DTO.TipoRecorrido.DTO;

namespace Backend_CruzRoja.AppService
{
    public class TipoRecorridoAppService : ControllerBase
    {
         
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoRecorridoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<ConsultaTipoRecorridoDTO>> Get()
        {
            return await context.TipoRecorridos

                .ProjectTo<ConsultaTipoRecorridoDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

    }
}


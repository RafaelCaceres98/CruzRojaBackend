using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.EstadoconductoresDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class EstadoConductoresAppService : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EstadoConductoresAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<EstadoConductoresConsultaDTO>> Get()
        {
            return await context.EstadoConductores

                .ProjectTo<EstadoConductoresConsultaDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }

}


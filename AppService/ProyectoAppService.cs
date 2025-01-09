using AutoMapper.QueryableExtensions;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Backend_CruzRoja.DTO.ProyectoDTO;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class ProyectoAppService: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProyectoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<ConsultaProyectoDTO>> Get()
        {
            return await context.Proyectos

                .ProjectTo<ConsultaProyectoDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.CategoComprasYServiciosDTO;
using Backend_CruzRoja.DTO.ConductorDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class CategoComprasYServiciosAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoComprasYServiciosAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Proyecta todos los regristros
        public async Task<IEnumerable<CategoComprasYServiciosDTO>> Get()
        {
            return await context.CategoriaComprasYServicios

                .ProjectTo<CategoComprasYServiciosDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

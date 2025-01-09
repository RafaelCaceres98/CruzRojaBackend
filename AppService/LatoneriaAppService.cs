using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.LatoneriaDTO;
using Backend_CruzRoja.DTO.MarcaVehiculoDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class LatoneriaAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LatoneriaAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<LatoneriaConsultaDTO>> Get()
        {
            return await context.Latonerias

                .ProjectTo<LatoneriaConsultaDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

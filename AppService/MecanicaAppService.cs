using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.LatoneriaDTO;
using Backend_CruzRoja.DTO.MecanicaDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class MecanicaAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MecanicaAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<MecanicaConsultaDTO>> Get()
        {
            return await context.Mecanicas

                .ProjectTo<MecanicaConsultaDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

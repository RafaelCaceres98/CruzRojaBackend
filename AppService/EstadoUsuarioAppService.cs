using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.EstadousuarioDTO;
using Backend_CruzRoja.DTO.LatoneriaDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class EstadoUsuarioAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EstadoUsuarioAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        //consulta todos los registros
        public async Task<IEnumerable<EstadoUsuarioConsultaDTO>> Get()
        {
            return await context.EstadoUsuarios

                .ProjectTo<EstadoUsuarioConsultaDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

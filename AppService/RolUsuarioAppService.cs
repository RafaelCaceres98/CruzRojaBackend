using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.EstadousuarioDTO;
using Backend_CruzRoja.DTO.RolUsuarioDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class RolUsuarioAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RolUsuarioAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<ConsultaRolUsuarioDTO>> Get()
        {
            return await context.RolUsuarios

                .ProjectTo<ConsultaRolUsuarioDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

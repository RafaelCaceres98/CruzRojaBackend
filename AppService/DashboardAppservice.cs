using AutoMapper;
using Backend_CruzRoja.DTO.DashBoardDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class DashboardAppservice : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DashboardAppservice(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Metodo para llenar el Dashboard
        public async Task<DashboarDTO> GetDashboardData()
        {

            var dashboard = new DashboarDTO
            {
                Conductores = await context.Conductores.CountAsync(),

                Usuarios = await context.Usuarios.CountAsync(),

                Mantenimiento = await context.Mantenimientos.CountAsync(),

                Hambunlancias = await context.Vehiculos.CountAsync(),

                HambunlanciasActivas = await context.Vehiculos.CountAsync(v => v.Esactivo),

                HambunlanciasInactivas = await context.Vehiculos.CountAsync(v => !v.Esactivo),


            };

            return dashboard;
        }
    }
}

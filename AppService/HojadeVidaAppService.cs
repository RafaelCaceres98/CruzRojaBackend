using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.ConductorDTO;
using Backend_CruzRoja.DTO.HojaDeVidaDTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class HojadeVidaAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HojadeVidaAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Proyecta todos los regristros
        public async Task<IEnumerable<HojadeVidaDTO>> Get()
        {
            return await context.HojadeVidas

                .ProjectTo<HojadeVidaDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        //Creando un nuevo registro
        public async Task<HojadeVidaDTO> Post(HojadeVidaDTO  hojadeVidaDTO)
        {
            HojadeVida  hojadeVida = new HojadeVida
            {
                VehiculoId = hojadeVidaDTO.VehiculoId,
                CategoriaComprasYServiciosId = hojadeVidaDTO.CategoriaComprasYServiciosId,
                Descripcion = hojadeVidaDTO.Descripcion,
                TipoMantenimientoId = hojadeVidaDTO.TipoMantenimientoId,
                KilometrajeActual = hojadeVidaDTO.KilometrajeActual,
                KIlometrajeDeCierre = hojadeVidaDTO.KIlometrajeDeCierre,
                Fecha = DateTime.Now, // es la fecha en la que se hizo el registro,
                ProveedorDeServicio = hojadeVidaDTO.ProveedorDeServicio,
                NumFactura = hojadeVidaDTO.NumFactura,
                ValorPagado = hojadeVidaDTO.ValorPagado,
                ConductorId = hojadeVidaDTO.ConductorId,
                Observaciones = hojadeVidaDTO.Observaciones
            };

            context.Add(hojadeVida);
            await context.SaveChangesAsync();

            return hojadeVidaDTO;
        }


      


    }
}

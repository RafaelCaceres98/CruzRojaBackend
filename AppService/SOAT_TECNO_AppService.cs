using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.SOAT_TECNO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class SOAT_TECNO_AppService :ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SOAT_TECNO_AppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ResponseDTO>Post (SOAtTECNOCreacionDTO sOAtTECNOCreacionDTO)
        {
            var responseDTO = new ResponseDTO();
            var NuevoSOAT_TECNO = new SOAT_TECNO
            {
                Descripcion = sOAtTECNOCreacionDTO.Descripcion,
                VehiculoId = sOAtTECNOCreacionDTO.VehiculoId
            };

            foreach (var soat in sOAtTECNOCreacionDTO.SOATs)
            {
                var soatnuevo = new SOAT
                {
                    FechaSolicitud = soat.FechaSolicitud,
                    FechaVencimiento = soat.FechaVencimiento,
                    Periodicidad = soat.Periodicidad,
                };
                NuevoSOAT_TECNO.SOATs.Add(soatnuevo);
            }

            foreach (var TECNODTO in sOAtTECNOCreacionDTO.TECNOMECANICAs)
            {
                var TECNOnuevo = new TECNOMECANICA
                {
                    FechaSolicitud = TECNODTO.FechaSolicitud,
                    FechaVencimiento = TECNODTO.FechaVencimiento,
                    Periodicidad = TECNODTO.Periodicidad,
                };
                NuevoSOAT_TECNO.TECNOMECANICAs.Add(TECNOnuevo);
            }

            if (NuevoSOAT_TECNO.SOATs.Any() || NuevoSOAT_TECNO.TECNOMECANICAs.Any())
            {
                context.SOAT_TECNOs.Add(NuevoSOAT_TECNO);
                await context.SaveChangesAsync();
                responseDTO.Data = mapper.Map<SOAtTECNOCreacionDTO>(NuevoSOAT_TECNO);
            }
            else
            {
                responseDTO.Mensaje = "Debe contener al menos una transacción.";
            }

            return responseDTO;

        }

        public async Task<IEnumerable<SOAtTECNOCreacionDTO>> Get()
        {
            return await context.SOAT_TECNOs
                .ProjectTo<SOAtTECNOCreacionDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }


    }
}
